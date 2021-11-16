using ColorViewer.Infrastructure;
using ColourModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ColorViewer.ViewModel
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        private Colour _brush;
        private Colour _selectedColour;
        private SolidColorBrush _brushColour;
        private DelegateCommand _addCommand;
        private DelegateCommand _deleteCommand;
        private DelegateCommand _saveCommand;
        public ObservableCollection<Colour> Colours { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(obj =>
                {
                    Colours.Add(Brush);
                }));
            }
        }

        public DelegateCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new DelegateCommand(obj =>
                {
                    Colours.Remove(SelectedColour);
                }));
            }
        }

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new DelegateCommand(obj =>
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Colour>));
                    using (var fs = File.Create("Colours.xml"))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            xs.Serialize(sw, Colours);
                        }
                    }
                }));
            }
        }

        public Colour SelectedColour
        {
            get => _selectedColour;
            set
            {
                if(_selectedColour != value)
                {
                    _selectedColour = value;
                    OnPropertyChanged();
                }
            }
        }
        public SolidColorBrush BrushColour
        {
            get => _brushColour;
            set
            {
                if(_brushColour != value)
                {
                    _brushColour = value;
                    OnPropertyChanged();
                }
            }
        }
        public Colour Brush
        {
            get => _brush;
            set
            {
                if (_brush != value)
                {
                    _brush = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Blue
        {
            get => _brush.Blue;
            set
            {
                if (_brush.Blue != value)
                {
                    _brush.Blue = value;
                    BrushColour = new SolidColorBrush(Color.FromArgb((byte)_brush.Alpha, (byte)_brush.Red, (byte)_brush.Green, (byte)_brush.Blue));
                    OnPropertyChanged();
                }
            }
        }
        public int Red
        {
            get => _brush.Red;
            set
            {
                if (_brush.Red != value)
                {
                    _brush.Red = value;
                    BrushColour = new SolidColorBrush(Color.FromArgb((byte)_brush.Alpha, (byte)_brush.Red, (byte)_brush.Green, (byte)_brush.Blue));
                    OnPropertyChanged();
                }
            }
        }
        public int Green
        {
            get => _brush.Green;
            set
            {
                if (_brush.Green != value)
                {
                    _brush.Green = value;
                    BrushColour = new SolidColorBrush(Color.FromArgb((byte)_brush.Alpha, (byte)_brush.Red, (byte)_brush.Green, (byte)_brush.Blue));
                    OnPropertyChanged();
                }
            }
        }
        public int Alpha
        {
            get => _brush.Alpha;
            set
            {
                if (_brush.Alpha != value)
                {
                    _brush.Alpha = value;
                    BrushColour = new SolidColorBrush(Color.FromArgb((byte)_brush.Alpha, (byte)_brush.Red, (byte)_brush.Green, (byte)_brush.Blue));
                    OnPropertyChanged();
                }
            }
        }

        public MainWindowViewModel()
        {
            _brush = new Colour();
            _selectedColour = new Colour();
            Colours = new ObservableCollection<Colour>();
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
