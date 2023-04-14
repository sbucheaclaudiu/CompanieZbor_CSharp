namespace AgentieZboruriMPP.domain
{
    public class Entity<ID>
    {
        private ID Id;

        public Entity(ID id)
        {
            this.Id = id;
        }

        public ID getId()
        {
            return Id;
        }

        public void setID(ID new_id)
        {
            this.Id = new_id;
        }

        public override string ToString()
        {
            return "Entity: " + "id = " + Id;
        }

    }
}