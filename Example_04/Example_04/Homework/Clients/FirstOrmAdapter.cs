using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public class FirstOrmAdapter : IOrmAdapter
    {
        private readonly IFirstOrm<DbUserEntity> _userOrm;
        private readonly IFirstOrm<DbUserInfoEntity> _userInfoOrm;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> userOrm, IFirstOrm<DbUserInfoEntity> userInfoOrm)
        {
            _userOrm = userOrm;
            _userInfoOrm = userInfoOrm;
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _userOrm.Add(user);
            _userInfoOrm.Add(userInfo);
        }

        public (DbUserEntity, DbUserInfoEntity) Read(int userId)
        {
            var user = _userOrm.Read(userId);
            var userInfo = _userInfoOrm.Read(user.InfoId);
            return (user, userInfo);
        }

        public void Delete(int userId)
        {
            var user = _userOrm.Read(userId);
            var userInfo = _userInfoOrm.Read(user.InfoId);

            _userInfoOrm.Delete(userInfo);
            _userOrm.Delete(user);
        }
    }
}
