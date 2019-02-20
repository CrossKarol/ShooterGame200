#region Includes

#endregion

namespace ShooterGame200
{ 
    public class PlayerValuePacket
    {

        public object value;
        public int playerId;

        public PlayerValuePacket(int PLAYERID, object VALUE)
        {
            playerId = PLAYERID;
            value = VALUE;
        }

    }
}
