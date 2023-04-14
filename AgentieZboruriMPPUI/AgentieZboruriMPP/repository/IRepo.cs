using AgentieZboruriMPP.domain;
using System.Collections.Generic;

namespace AgentieZboruriMPP.repository
{
    public interface IRepo<ID, E> where E : Entity<ID>
    {
        /**
         * Returneaza toate entitatile din BD
         */
        List<E> getAll();

        /**
         * Returneaza entitatea cu id-ul dat
         */
        E getById(ID entityId);

        /**
         * Modifica entitatea din BD
         */
        void update(E updateEntity);

        /**
         * Adauga o entitate noua in BD
         */
        void insert(E newEntity);

        /**
         * Sterge entitatea din BD
         */
        void delete(E deleteEntity);
    }
}