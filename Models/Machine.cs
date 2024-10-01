namespace Vaskebjørnen.Models
{
    public class Machine
    {
        private int _number;
        private MachineType _type;
        public enum MachineType { Vaskemaskine, Tørretumbler, Rullemaskine }

        public Machine()
        {

        }

        public Machine(int number, MachineType type)
        {
            _number = number;
            _type = type;
        }

        public int Number
            { get { return _number; } }

        public MachineType Type
            { get { return _type; } }
    }
}
