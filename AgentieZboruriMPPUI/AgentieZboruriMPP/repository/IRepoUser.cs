using AgentieZboruriMPP.domain;
using System;

namespace AgentieZboruriMPP.repository
{
    public interface IRepoUser : IRepo<string, User>
    {
        User findUser(String username, String password);
    }
}