using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BusinessLogic
{
    public interface IPreferencesViewModel
    {
        uint BoardsQuantity { get; }
        float BoardThickness { get; }
        MaterialPreference Material { get; }
        MaterialPreference SurfaceFinish { get; }
        bool IsConfirmed { get; }
    }
    public class PreferencesViewModel : ViewModelBase, IPreferencesViewModel
    {
        private static readonly MaterialColor[] StandardSolderMaskColors =
        {
            new MaterialColor("Green", 0x00ff00),
            new MaterialColor("OtherSolderMaskColor", 0x4da4a8),
            new MaterialColor("OtherSolderMaskColor2", 0x6ea15c),
        };

        private static readonly MaterialPreference[] StandardMaterials =
        {
            new MaterialPreference("Arlon", 160, 0),
            new MaterialPreference("OtherMaterial", 70, 2.5),
            new MaterialPreference("OtherMaterial2", 50, 1),
        };

        private static readonly MaterialPreference[] StandardSurfaceFinishes =
        {
            new MaterialPreference("ENEPIG", 75, 3),
            new MaterialPreference("OtherSurfaceFinish", 20, 1),
            new MaterialPreference("OtherSurfaceFinish2", 10, 0),
        };

        private static readonly MaterialColor[] StandardSilkscreenColors =
        {
            new MaterialColor("White", 0xffffff),
            new MaterialColor("OtherSilkscreenColor", 0x6990c7),
            new MaterialColor("OtherSilkscreenColor2", 0xb285cc),
        };
        private readonly IQuoteViewModel _quote;
        private string _projectName = "BC0001";
        private uint _zipcode = 92122;
        private uint _boardsQuantity = 20;
        private float _boardThickness = 1.57f;
        private MaterialColor _solderMaskColor = StandardSolderMaskColors[0];
        private MaterialPreference _material = StandardMaterials[0];
        private MaterialPreference _surfaceFinish = StandardSurfaceFinishes[0];
        private bool _leadFree = true;
        private bool _itar = false;
        private TentingForVias _tentingForVias = TentingForVias.None;
        private ControlledImpedance _controlledImpedance = ControlledImpedance.None;
        private FluxType _fluxType = FluxType.NoClean;
        private IpcClass _ipcClass = IpcClass.Class2;
        private Stackup _stackup = Stackup.Standard;
        private MaterialColor _silkscreenColor = StandardSilkscreenColors[0];
        private string _cooperWeightOnInnerLayer = "1.0oz";
        private string _cooperWeightOnOuterLayer = "1.0oz";
        private string _notes = String.Empty;

        private bool _isConfirmed = false;

        public string ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value;
                OnPropertyChanged(nameof(ProjectName));
                OnAnyPropertyChanged();
            }
        }

        public uint ZipCode
        {
            get => _zipcode;
            set
            {
                _zipcode = value;
                OnPropertyChanged(nameof(ZipCode));
                OnAnyPropertyChanged();
            }
        }

        public uint BoardsQuantity
        {
            get => _boardsQuantity;
            set
            {
                _boardsQuantity = value;
                OnPropertyChanged(nameof(BoardsQuantity));
                OnAnyPropertyChanged();
            }
        }

        public float BoardThickness
        {
            get => _boardThickness;
            set
            {
                _boardThickness = Math.Abs(value);
                OnPropertyChanged(nameof(BoardThickness));
                OnAnyPropertyChanged();
            }
        }

        public ObservableCollection<MaterialPreference> Materials { get; }
            = new ObservableCollection<MaterialPreference>(StandardMaterials);

        public MaterialPreference Material
        {
            get => _material;
            set
            {
                _material = value;
                OnPropertyChanged(nameof(Material));
                OnAnyPropertyChanged();
            }
        }

        public ObservableCollection<MaterialPreference> SurfaceFinishes { get; }
            = new ObservableCollection<MaterialPreference>(StandardSurfaceFinishes);

        public MaterialPreference SurfaceFinish
        {
            get => _surfaceFinish;
            set
            {
                _surfaceFinish = value;
                OnPropertyChanged(nameof(SurfaceFinish));
                OnAnyPropertyChanged();
            }
        }


        public ObservableCollection<MaterialColor> SolderMaskColors { get; }
            = new ObservableCollection<MaterialColor>(StandardSolderMaskColors);

        public MaterialColor SolderMaskColor
        {
            get => _solderMaskColor;
            set
            {
                _solderMaskColor = value;
                OnPropertyChanged(nameof(SolderMaskColor));
                OnAnyPropertyChanged();
            }
        }

        public bool LeadFree
        {
            get => _leadFree;
            set
            {
                _leadFree = value;
                OnPropertyChanged(nameof(LeadFree));
                OnAnyPropertyChanged();
            }
        }

        public bool Itar
        {
            get => _itar;
            set
            {
                _itar = value;
                OnPropertyChanged(nameof(Itar));
                OnAnyPropertyChanged();
            }
        }

        public IpcClass IpcClass
        {
            get => _ipcClass;
            set
            {
                _ipcClass = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public FluxType FluxType
        {
            get => _fluxType;
            set
            {
                _fluxType = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public ControlledImpedance ControlledImpedance
        {
            get => _controlledImpedance;
            set
            {
                _controlledImpedance = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public TentingForVias TentingForVias
        {
            get => _tentingForVias;
            set
            {
                _tentingForVias = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public Stackup Stackup
        {
            get => _stackup;
            set
            {
                _stackup = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public ObservableCollection<MaterialColor> SilkscreenColors { get; }
            = new ObservableCollection<MaterialColor>(StandardSilkscreenColors);

        public MaterialColor SilkscreenColor
        {
            get => _silkscreenColor;
            set
            {
                _silkscreenColor = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }


        public ObservableCollection<string> CooperWeightOnInnerLayers { get; } = new ObservableCollection<string>()
        {
            "1.0oz",
            "2.0oz",
            "3.0oz"
        };

        public string CooperWeightOnInnerLayer
        {
            get => _cooperWeightOnInnerLayer;
            set
            {
                _cooperWeightOnInnerLayer = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public ObservableCollection<string> CooperWeightOnOuterLayers { get; } = new ObservableCollection<string>()
        {
            "1.0oz",
            "2.0oz",
            "3.0oz"
        };

        public string CooperWeightOnOuterLayer
        {
            get => _cooperWeightOnOuterLayer;
            set
            {
                _cooperWeightOnOuterLayer = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
                OnAnyPropertyChanged();
            }
        }

        public ActionCommand DiscardToDefaultCommand { get; }
        public ActionCommand SaveAndContinueCommand { get; }

        private void OnAnyPropertyChanged()
        {
            IsConfirmed = false;
        }
        public bool IsConfirmed
        {
            get => _isConfirmed;
            set
            {
                _isConfirmed = value;
                OnPropertyChanged();
            }
        }

        public PreferencesViewModel(IQuoteViewModel quote)
        {
            DiscardToDefaultCommand = new ActionCommand(OnDiscardToDefault);
            SaveAndContinueCommand = new ActionCommand(OnSaveAndContinue);
            _quote = quote;
        }

        private void OnDiscardToDefault(object arg)
        {
            ProjectName = "BC0001";
            ZipCode = 92122;
            BoardsQuantity = 20;
            BoardThickness = 1.57f;
            SolderMaskColor = StandardSolderMaskColors[0];
            Material = StandardMaterials[0];
            SurfaceFinish = StandardSurfaceFinishes[0];
            LeadFree = true;
            Itar = false;
            TentingForVias = TentingForVias.None;
            ControlledImpedance = ControlledImpedance.None;
            FluxType = FluxType.NoClean;
            IpcClass = IpcClass.Class2;
            Stackup = Stackup.Standard;
            SilkscreenColor = StandardSilkscreenColors[0];
            CooperWeightOnInnerLayer = "1.0oz";
            CooperWeightOnOuterLayer = "1.0oz";
            Notes = String.Empty;

            IsConfirmed = false;
        }

        private void OnSaveAndContinue(object arg)
        {
            IsConfirmed = true;
            _quote.UpdateQuote(this);
        }
    }

    public class MaterialPreference : IImpact
    {
        public string Name { get; }
        public double CostImpact { get; }

        public double TimeImpact { get; }

        public MaterialPreference(string name, double costImpact, double timeImpact)
        {
            Name = name;
            CostImpact = costImpact;
            TimeImpact = timeImpact;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MaterialColor
    {
        public string Name { get; }
        public Int32 Color { get; }

        public MaterialColor(string name, Int32 color)
        {
            Name = name;
            Color = color;
        }
    }


}
