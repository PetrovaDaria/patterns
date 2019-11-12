using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class SecondOrmAdapter : IOrmAdapter
    {
        private readonly ISecondOrm _secondOrm;

        public SecondOrmAdapter(ISecondOrm secondOrm)
        {
            _secondOrm = secondOrm;
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _secondOrm.Context.Users.Add(user);
            _secondOrm.Context.UserInfos.Add(userInfo);
        }

        public (DbUserEntity, DbUserInfoEntity) Read(int userId)
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
            return (user, userInfo);
        }

        public void Delete(int userId)
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfoId = user.InfoId;
            _secondOrm.Context.Users.Remove(user);

            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == userInfoId);
            _secondOrm.Context.UserInfos.Remove(userInfo);
        }
    }
}
