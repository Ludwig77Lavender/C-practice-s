using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp17
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowInfoButton.Click += ShowInfoButton_Click;
        }

        private void ShowInfoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string route = RouteTextBox.Text;
                string departureTime = DepartureTimeComboBox.Text;
                string arrivalTime = ArrivalTimeComboBox.Text;

                if (string.IsNullOrWhiteSpace(route) || string.IsNullOrWhiteSpace(departureTime) || string.IsNullOrWhiteSpace(arrivalTime))
                {
                    ShowError("Заполните все поля маршрута и времени.");
                    return;
                }

                if (IsCarDataFilled() && !IsTrainDataFilled())
                {
                    Car car = new Car(route, departureTime, arrivalTime, CarDepartureTextBox.Text, CarArrivalTextBox.Text, int.Parse(CarSeatsTextBox.Text), CarCarrierTextBox.Text);
                    ShowInfo("Информация об автомобиле", car.GetInfo());
                }
                else if (!IsCarDataFilled() && IsTrainDataFilled())
                {
                    Train train = new Train(route, departureTime, arrivalTime, TrainNumberTextBox.Text, TrainNameTextBox.Text, int.Parse(TrainSeatsCarriagesTextBox.Text), int.Parse(TrainPlatzCarriagesTextBox.Text), int.Parse(TrainCoupeCarriagesTextBox.Text), int.Parse(TrainLuxuryCarriagesTextBox.Text));
                    if (IsExpressDataFilled())
                    {
                        Express express = new Express(route, departureTime, arrivalTime, TrainNumberTextBox.Text, TrainNameTextBox.Text, int.Parse(TrainSeatsCarriagesTextBox.Text), int.Parse(TrainPlatzCarriagesTextBox.Text), int.Parse(TrainCoupeCarriagesTextBox.Text), int.Parse(TrainLuxuryCarriagesTextBox.Text), double.Parse(ExpressSpeedTextBox.Text));
                        ShowInfo("Информация об экспрессе", express.GetInfo());
                    }
                    else
                    {
                        ShowInfo("Информация о поезде", train.GetInfo());
                    }
                }
                else if (IsCarDataFilled() && IsTrainDataFilled())
                {
                    Car car = new Car(route, departureTime, arrivalTime, CarDepartureTextBox.Text, CarArrivalTextBox.Text, int.Parse(CarSeatsTextBox.Text), CarCarrierTextBox.Text);
                    Train train = new Train(route, departureTime, arrivalTime, TrainNumberTextBox.Text, TrainNameTextBox.Text, int.Parse(TrainSeatsCarriagesTextBox.Text), int.Parse(TrainPlatzCarriagesTextBox.Text), int.Parse(TrainCoupeCarriagesTextBox.Text), int.Parse(TrainLuxuryCarriagesTextBox.Text));

                    ShowInfo("Информация об автомобиле", car.GetInfo());

                    if (IsExpressDataFilled())
                    {
                        Express express = new Express(route, departureTime, arrivalTime, TrainNumberTextBox.Text, TrainNameTextBox.Text, int.Parse(TrainSeatsCarriagesTextBox.Text), int.Parse(TrainPlatzCarriagesTextBox.Text), int.Parse(TrainCoupeCarriagesTextBox.Text), int.Parse(TrainLuxuryCarriagesTextBox.Text), double.Parse(ExpressSpeedTextBox.Text));
                        ShowInfo("Информация об экспрессе", express.GetInfo());
                    }
                    else
                    {
                        ShowInfo("Информация о поезде", train.GetInfo());
                    }
                }
                else
                {
                    ShowError("Заполните данные либо для автомобиля, либо для поезда.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка: " + ex.Message);
            }
        }

        private bool IsCarDataFilled()
        {
            return !string.IsNullOrWhiteSpace(CarDepartureTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(CarArrivalTextBox.Text) &&
                   int.TryParse(CarSeatsTextBox.Text, out _) &&
                   !string.IsNullOrWhiteSpace(CarCarrierTextBox.Text);
        }

        private bool IsTrainDataFilled()
        {
            return !string.IsNullOrWhiteSpace(TrainNumberTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(TrainNameTextBox.Text) &&
                   int.TryParse(TrainSeatsCarriagesTextBox.Text, out _) &&
                   int.TryParse(TrainPlatzCarriagesTextBox.Text, out _) &&
                   int.TryParse(TrainCoupeCarriagesTextBox.Text, out _) &&
                   int.TryParse(TrainLuxuryCarriagesTextBox.Text, out _);
        }

        private bool IsExpressDataFilled()
        {
            return double.TryParse(ExpressSpeedTextBox.Text, out _);
        }

        private void ShowInfo(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public class TransportVehicle
    {
        public string Route { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public TransportVehicle(string route, string departureTime, string arrivalTime)
        {
            Route = route;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public virtual string GetInfo()
        {
            return $"Транспортное средство, следующее по маршруту {Route}, отправляется в {DepartureTime}, прибывает в {ArrivalTime}.";
        }
    }

    public class Car : TransportVehicle
    {
        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public int SeatCount { get; set; }
        public string CarrierName { get; set; }

        public Car(string route, string departureTime, string arrivalTime, string departurePlace, string arrivalPlace, int seatCount, string carrierName)
            : base(route, departureTime, arrivalTime)
        {
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            SeatCount = seatCount;
            CarrierName = carrierName;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" Место отправления автомобиля - {DeparturePlace}, место прибытия автомобиля - {ArrivalPlace}, количество мест - {SeatCount}, перевозчик - {CarrierName}.";
        }
    }

    public class Train : TransportVehicle
    {
        public string TrainNumber { get; set; }
        public string TrainName { get; set; }
        public int SeatCarCount { get; set; }
        public int SleeperCarCount { get; set; }
        public int CompartmentCarCount { get; set; }
        public int LuxuryCarCount { get; set; }

        public Train(string route, string departureTime, string arrivalTime, string trainNumber, string trainName, int seatCarCount, int sleeperCarCount, int compartmentCarCount, int luxuryCarCount)
            : base(route, departureTime, arrivalTime)
        {
            TrainNumber = trainNumber;
            TrainName = trainName;
            SeatCarCount = seatCarCount;
            SleeperCarCount = sleeperCarCount;
            CompartmentCarCount = compartmentCarCount;
            LuxuryCarCount = luxuryCarCount;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" Поезд №{TrainNumber} {TrainName} с количеством вагонов: сидячих - {SeatCarCount}, плацкартных - {SleeperCarCount}, купейных - {CompartmentCarCount}, Люкс - {LuxuryCarCount}.";
        }
    }

    public class Express : Train
    {
        public double Speed { get; set; }

        public Express(string route, string departureTime, string arrivalTime, string trainNumber, string trainName, int seatCarCount, int sleeperCarCount, int compartmentCarCount, int luxuryCarCount, double speed)
            : base(route, departureTime, arrivalTime, trainNumber, trainName, seatCarCount, sleeperCarCount, compartmentCarCount, luxuryCarCount)
        {
            Speed = speed;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" Относится к типу скоростных поездов с развиваемой скоростью до {Speed} км/ч и используется как экспресс.";
        }
    }
}