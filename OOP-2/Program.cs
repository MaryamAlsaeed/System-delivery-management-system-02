namespace OOP_2
{
    internal class Program
    {
        #region Shipment class
        public class Shipment
        {
            internal string _trackingCode;
            internal string _description;
            internal double _weight;
            internal double _deliveryFee;
            public DeliveryAddress Destination { get; set; }
            public string TrackingCode
            {
                get { return _trackingCode; }
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _trackingCode = value;
                }
            }

            public string Description
            {
                get { return _description; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _description = value;
                }
            }

            public double Weight
            {
                get { return _weight; }
                set
                {
                    if (value > 0)
                        _weight = value;
                }
            }

            public double DeliveryFee
            {
                get { return _deliveryFee; }
                private set
                {
                    if (value > 0)
                        _deliveryFee = value;
                }
            }

            public double EstimatedCost
            {
                get { return DeliveryFee + (Weight * 5); }
            }
            public Shipment(string trackingCode)
            {
                this.TrackingCode = trackingCode;
                Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            }
            public Shipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination)
            {
                this.TrackingCode = trackingCode;
                Description = description;
                Weight = weight;
                DeliveryFee = deliveryFee;
                Destination = destination;
            }
            public void UpdateDeliveryFee(double newFee)
            {
                if (newFee > 0)
                    DeliveryFee = (double)newFee;
            }
            public void PrintShipment()
            {
                Console.WriteLine($"Tracking code: {TrackingCode}");
                Console.WriteLine($"Description: {Description}");
                Console.WriteLine($"Weight: {Weight} KG");
                Console.WriteLine($"Delivery Fee: {DeliveryFee}");
                Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
                Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            }
        }
        #endregion

        #region Delivery class
        public class DeliveryCenter
        {
            private Shipment[] shipments;

            public DeliveryCenter()
            {
                shipments = new Shipment[10];
            }

            public Shipment this[int index]
            {
                get
                {
                    if (index >= 0 && index < shipments.Length)
                        return shipments[index];
                    return default;
                }
                set
                {
                    if (index >= 0 && index < shipments.Length)
                        shipments[index] = value;
                }
            }

            public Shipment this[string trackingCode]
            {
                get
                {
                    for (int i = 0; i < shipments.Length; i++)
                    {
                        if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                            return shipments[i];
                    }
                    return default;
                }
            }

            public bool AddShipment(Shipment shipment)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] == null)
                    {
                        shipments[i] = shipment;
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion
        static void Main(string[] args)
        {
            
        }
    }
}
