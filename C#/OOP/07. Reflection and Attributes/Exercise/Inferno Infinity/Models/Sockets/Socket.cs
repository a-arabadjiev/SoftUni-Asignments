namespace P07.InfernoInfinity.Models.Sockets
{
    using P07.InfernoInfinity.Models.Gems.Base;

    public class Socket
    {
        public Socket(Gem gem)
        {
            this.Gem = gem;
        }

        public Gem Gem { get; set; }
    }
}
