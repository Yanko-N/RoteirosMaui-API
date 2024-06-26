﻿using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.Abstractions
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {

        SQLiteConnection Connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            Connection = new SQLiteConnection(Constants.DataBasePath, Constants.Flags);

            //Apenas corre se a tabela não existir
            Connection.CreateTable<T>();
        }
        public void DeleteItem(T item)
        {
            try
            {
                Connection.Delete(item,true);
            }
            catch (Exception ex)
            {

                StatusMessage = $"{ex.Message}";
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return Connection.Table<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"{ex.Message}";
            }
            return null;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = $"{ex.Message}";
            }
            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return Connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"{ex.Message}";
            }
            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"{ex.Message}";
            }
            return null;
        }

        public void SaveItem(T item)
        {
            int result = 0;
            try
            {
                if (item.Id != 0)
                {
                    result =
                         Connection.Update(item);
                    StatusMessage =
                         $"{result} row(s) updated";
                }
                else
                {
                    result = Connection.Insert(item);
                    StatusMessage =
                         $"{result} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
        }

        public void SaveItemWithChildren(T item, bool recursive = false)
        {
           Connection.InsertWithChildren(item, recursive);
        }

        public List<T> GetItemsWithChildren()
        {
            try
            {
                return Connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"{ex.Message}";
            }
            return null;
        }
    }
}
