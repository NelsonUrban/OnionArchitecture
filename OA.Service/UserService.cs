using OA.Data;
using OA.Repository;
using System;
using System.Collections.Generic;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<UserProfile> userProfileRepository;

        public UserService( IRepository<User> userRepository , IRepository<UserProfile> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
            this.userRepository = userRepository;
        
        }
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }
        public User GetUser( long id)
        {
            return userRepository.Get(id);
        }
        public void InsertUser(User user)
        {
            this.userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            UserProfile userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

    }
}
