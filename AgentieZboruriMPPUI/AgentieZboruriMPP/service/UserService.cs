using AgentieZboruriMPP.repository;
using AgentieZboruriMPP.domain;
using System.Collections.Generic;
using System;

namespace AgentieZboruriMPP.service
{
    public class UserService
    {
        protected IRepoUser repo;

        public UserService(IRepoUser repo)
        {
            this.repo = repo;
        }

        public List<User> getAll()
        {
            return this.repo.getAll();
        }

        public User findUser(String username, String password)
        {
            return repo.findUser(username, password);
        }
    }
}