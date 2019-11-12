using System.Linq;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private readonly IOrmAdapter _ormAdapter;

        //private IFirstOrm<DbUserEntity> _firstOrm1;
        //private IFirstOrm<DbUserInfoEntity> _firstOrm2;

        //private ISecondOrm _secondOrm;

        //private bool _useFirstOrm = false;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            return _ormAdapter.Read(userId);

            /*
            if (_useFirstOrm)
            {
                var user = _firstOrm1.Read(userId);
                var userInfo = _firstOrm2.Read(user.InfoId);
                return (user, userInfo);
            }
            else
            {
                var user = _secondOrm.Context.Users.First(i => i.Id == userId);
                var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
                return (user, userInfo);
            }
            */
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _ormAdapter.Add(user, userInfo);

            /*
            if (_useFirstOrm)
            {
                _firstOrm1.Add(user);
                _firstOrm2.Add(userInfo);
            }
            else
            {
                _secondOrm.Context.Users.Add(user);
                _secondOrm.Context.UserInfos.Add(userInfo);
            }
            */

            // you should create DbUserEntity and DbUserInfoEntity via _ormAdapter
        }

        public void Remove(int userId)
        {
            _ormAdapter.Delete(userId);

            /*
            if (_useFirstOrm)
            {
                var user = _firstOrm1.Read(userId);
                var userInfo = _firstOrm2.Read(user.InfoId);

                _firstOrm2.Delete(userInfo);
                _firstOrm1.Delete(user);
            }
            else
            {
                var user = _secondOrm.Context.Users.First(i => i.Id == userId);
                var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);

                _secondOrm.Context.UserInfos.Remove(userInfo);
                _secondOrm.Context.Users.Remove(user);
            }
            */

            // you should remove DbUserEntity and DbUserInfoEntity via _ormAdapter
        }

        public UserClient(IOrmAdapter ormAdapter)
        {
            _ormAdapter = ormAdapter;
        }
    }
}
