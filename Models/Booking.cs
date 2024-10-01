using Microsoft.Identity.Client;

namespace Vaskebjørnen.Models
{
    public class Booking
    {
        private DateTime _time;
        private string _appartmentNumber;
        private int _machineNumber;
        private DateTime _timeOfBooking;

        public Booking()
        {

        }

        public Booking(DateTime time, string appartmentNumber, int machineNumber)
        {
            _time = time;
            _appartmentNumber = appartmentNumber;
            _machineNumber = machineNumber;
            _timeOfBooking = DateTime.Now;
        }

        public DateTime Time
        { get { return _time; } }
        public string AppartmentNumber
        { get { return _appartmentNumber; } }
        public int MachineNumber 
        { get { return _machineNumber; } }
        public DateTime TimeOfBooking
        { get { return _timeOfBooking; } }
    }
}
