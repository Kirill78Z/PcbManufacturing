using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BusinessLogic
{
    public class PreferencesViewModel : ViewModelBase
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

        private string _projectName = "BC0001";
        private UInt32 _zipcode = 92122;
        private uint _boardsQuantity = 20;
        private float _boardThickness = 1.57f;
        private MaterialColor _solderMaskColor = StandardSolderMaskColors[0];
        private MaterialPreference _material = StandardMaterials[0];
        private MaterialPreference _surfaceFinish = StandardSurfaceFinishes[0];
        private bool _leadFree = true;
        private bool _itar;
        private TentingForVias _tentingForVias;
        private ControlledImpedance _controlledImpedance;
        private FluxType _fluxType;
        private IpcClass _ipcClass = IpcClass.Class2;
        private Stackup _stackup;
        private MaterialColor _silkscreenColor = StandardSilkscreenColors[0];
        private string _cooperWeightOnInnerLayer = "1.0oz";
        private string _cooperWeightOnOuterLayer = "1.0oz";
        private string _notes;

        public string ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value;
                OnPropertyChanged(nameof(ProjectName));
            }
        }

        public UInt32 ZipCode
        {
            get => _zipcode;
            set
            {
                _zipcode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }

        public UInt32 BoardsQuantity
        {
            get => _boardsQuantity;
            set
            {
                _boardsQuantity = value;
                OnPropertyChanged(nameof(BoardsQuantity));
            }
        }

        public float BoardThickness
        {
            get => _boardThickness;
            set
            {
                _boardThickness = Math.Abs(value);
                OnPropertyChanged(nameof(BoardThickness));
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
            }
        }

        public bool LeadFree
        {
            get => _leadFree;
            set
            {
                _leadFree = value;
                OnPropertyChanged(nameof(LeadFree));
            }
        }

        public bool Itar
        {
            get => _itar;
            set
            {
                _itar = value;
                OnPropertyChanged(nameof(Itar));
            }
        }

        public IpcClass IpcClass
        {
            get => _ipcClass;
            set
            {
                _ipcClass = value;
                OnPropertyChanged();
            }
        }

        public FluxType FluxType
        {
            get => _fluxType;
            set
            {
                _fluxType = value;
                OnPropertyChanged();
            }
        }

        public ControlledImpedance ControlledImpedance
        {
            get => _controlledImpedance;
            set
            {
                _controlledImpedance = value;
                OnPropertyChanged();
            }
        }

        public TentingForVias TentingForVias
        {
            get => _tentingForVias;
            set
            {
                _tentingForVias = value;
                OnPropertyChanged();
            }
        }

        public Stackup Stackup
        {
            get => _stackup;
            set
            {
                _stackup = value;
                OnPropertyChanged();
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
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
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
