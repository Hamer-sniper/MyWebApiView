using MyWebApiView.Models;
using System.Net.Http;

namespace MyWebApiView.Interfaces
{
    public interface IDataBookData
    {
        /// <summary>
        /// Добавить токен в заголовок.
        /// </summary>
        /// <param name="accessToken">Токен</param>
        void AddTokenToClient(string accessToken);

        /// <summary>
        /// Получить все записи из БД.
        /// </summary>
        /// <returns>Список записей</returns>
        List<DataBook> GetAllDatabooks();

        /// <summary>
        /// Добавить запись в БД.
        /// </summary>
        /// <param name="dataBook">Запись</param>
        void CreateDataBook(DataBook dataBook);

        /// <summary>
        /// Получить запись из БД.
        /// </summary>
        /// <param name="dataBookId">Id записи</param>
        /// <returns>Запись</returns>
        DataBook ReadDataBook(int dataBookId);

        /// <summary>
        /// Изменить запсиь в БД.
        /// </summary>
        /// <param name="dataBook">Запись</param>
        void UpdateDataBook(DataBook dataBook);

        /// <summary>
        /// Изменить запсиь в БД по Id.
        /// </summary>
        /// <param name="dataBookId">Id записи</param>
        /// <param name="dataBook">Запись</param>
        void UpdateDataBookById(int dataBookId, DataBook dataBook);

        /// <summary>
        /// Удалить запись из БД.
        /// </summary>
        /// <param name="dataBook">Запись</param>
        void DeleteDataBook(DataBook dataBook);

        /// <summary>
        /// Удалить запись из БД по Id.
        /// </summary>
        /// <param name="dataBookId">Id записи</param>
        void DeleteDataBookById(int dataBookId);

        /// <summary>
        /// Логин (получить токен).
        /// </summary>
        /// <param name="UserName">Логин</param>
        /// <param name="Password">Пароль</param>
        void GetToken(string UserName, string Password);

        /// <summary>
        /// Логин (получить токен).
        /// </summary>
        /// <param name="UserName">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns>Токен</returns>
        string GetTokenString(string UserName, string Password);

        /// <summary>
        /// Зарегистрироваться.
        /// </summary>
        /// <param name="UserName">Логин</param>
        /// <param name="Password">Пароль</param>
        void Register(string UserName, string Password);

        /// <summary>
        /// Разлогиниться.
        /// </summary>
        void RemoveTokenFromClient();
    }
}