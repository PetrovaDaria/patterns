using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public interface IOrmAdapter // ITarget
    {
        void Add(DbUserEntity user, DbUserInfoEntity userInfo);
        (DbUserEntity, DbUserInfoEntity) Read(int userId);
        void Delete(int userId);
    }
}
