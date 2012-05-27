// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from swt on 2012-05-21 19:13:54Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace HP.SW.SWT.Data
{
    using System;
    using System.ComponentModel;
    using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
    using DbLinq.Data.Linq;
    using DbLinq.Vendor;
#endif  // MONO_STRICT
    using System.Data.Linq.Mapping;
    using System.Diagnostics;
    using MySql.Data.MySqlClient;
    using DbLinq.MySql;


    public partial class SwT : DataContext
    {

        #region Extensibility Method Declarations
        partial void OnCreated();
        #endregion

        public SwT(string connectionString) :
            base(new MySqlConnection(connectionString), new MySqlVendor())
        {
            this.OnCreated();
        }

        public SwT(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public SwT(IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Table<Cluster> Cluster
        {
            get
            {
                return this.GetTable<Cluster>();
            }
        }

        public Table<ExcelRow> ExcelRow
        {
            get
            {
                return this.GetTable<ExcelRow>();
            }
        }

        public Table<Holiday> Holiday
        {
            get
            {
                return this.GetTable<Holiday>();
            }
        }

        public Table<Period> Period
        {
            get
            {
                return this.GetTable<Period>();
            }
        }

        public Table<Resource> Resource
        {
            get
            {
                return this.GetTable<Resource>();
            }
        }

        public Table<Roles> Roles
        {
            get
            {
                return this.GetTable<Roles>();
            }
        }

        public Table<Task> Task
        {
            get
            {
                return this.GetTable<Task>();
            }
        }

        public Table<Ticket> Ticket
        {
            get
            {
                return this.GetTable<Ticket>();
            }
        }

        public Table<TicketComment> TicketComment
        {
            get
            {
                return this.GetTable<TicketComment>();
            }
        }

        public Table<Users> Users
        {
            get
            {
                return this.GetTable<Users>();
            }
        }

        public Table<UsersInRoles> UsersInRoles
        {
            get
            {
                return this.GetTable<UsersInRoles>();
            }
        }
    }

    #region Start MONO_STRICT
#if MONO_STRICT

	public partial class SwT
	{
		
		public SwT(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
    #region End MONO_STRICT
    #endregion
#else     // MONO_STRICT

    public partial class SwT
    {

        public SwT(IDbConnection connection) :
            base(connection, new DbLinq.MySql.MySqlVendor())
        {
            this.OnCreated();
        }

        public SwT(IDbConnection connection, IVendor sqlDialect) :
            base(connection, sqlDialect)
        {
            this.OnCreated();
        }

        public SwT(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) :
            base(connection, mappingSource, sqlDialect)
        {
            this.OnCreated();
        }
    }
    #region End Not MONO_STRICT
    #endregion
#endif     // MONO_STRICT
    #endregion

    [Table(Name = "swt.cluster")]
    public partial class Cluster : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _description;

        private int _idcLuster;

        private string _shortDescription;

        private EntitySet<Resource> _resource;

        private EntitySet<Ticket> _ticket;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnIdcLusterChanged();

        partial void OnIdcLusterChanging(int value);

        partial void OnShortDescriptionChanged();

        partial void OnShortDescriptionChanging(string value);
        #endregion


        public Cluster()
        {
            _resource = new EntitySet<Resource>(new Action<Resource>(this.Resource_Attach), new Action<Resource>(this.Resource_Detach));
            _ticket = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket_Attach), new Action<Ticket>(this.Ticket_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_idcLuster", Name = "IDCluster", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdcLuster
        {
            get
            {
                return this._idcLuster;
            }
            set
            {
                if ((_idcLuster != value))
                {
                    this.OnIdcLusterChanging(value);
                    this.SendPropertyChanging();
                    this._idcLuster = value;
                    this.SendPropertyChanged("IdcLuster");
                    this.OnIdcLusterChanged();
                }
            }
        }

        [Column(Storage = "_shortDescription", Name = "ShortDescription", DbType = "varchar(10)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string ShortDescription
        {
            get
            {
                return this._shortDescription;
            }
            set
            {
                if (((_shortDescription == value)
                            == false))
                {
                    this.OnShortDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._shortDescription = value;
                    this.SendPropertyChanged("ShortDescription");
                    this.OnShortDescriptionChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_resource", OtherKey = "DefaultCluster", ThisKey = "IdcLuster", Name = "fk_Res_Cluster")]
        [DebuggerNonUserCode()]
        public EntitySet<Resource> Resource
        {
            get
            {
                return this._resource;
            }
            set
            {
                this._resource = value;
            }
        }

        [Association(Storage = "_ticket", OtherKey = "IdcLuster", ThisKey = "IdcLuster", Name = "fk_Ticket_Cluster")]
        [DebuggerNonUserCode()]
        public EntitySet<Ticket> Ticket
        {
            get
            {
                return this._ticket;
            }
            set
            {
                this._ticket = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void Resource_Attach(Resource entity)
        {
            this.SendPropertyChanging();
            entity.Cluster = this;
        }

        private void Resource_Detach(Resource entity)
        {
            this.SendPropertyChanging();
            entity.Cluster = null;
        }

        private void Ticket_Attach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Cluster = this;
        }

        private void Ticket_Detach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Cluster = null;
        }
        #endregion
    }

    [Table(Name = "swt.excelrow")]
    public partial class ExcelRow : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _date;

        private string _description;

        private System.Nullable<System.DateTime> _endHour;

        private int _ideXcelRow;

        private int _idpEriod;

        private sbyte _scpcHarged;

        private System.Nullable<decimal> _scphOurs;

        private string _scpT;

        private string _scptIcket;

        private System.DateTime _startHour;

        private string _t;

        private string _ticket;

        private EntityRef<Period> _period = new EntityRef<Period>();

        private EntityRef<Resource> _resource = new EntityRef<Resource>();

        private EntityRef<Ticket> _ticketTicket = new EntityRef<Ticket>();

        private EntityRef<Resource> _resource1 = new EntityRef<Resource>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnEndHourChanged();

        partial void OnEndHourChanging(System.Nullable<System.DateTime> value);

        partial void OnIdeXcelRowChanged();

        partial void OnIdeXcelRowChanging(int value);

        partial void OnIdpEriodChanged();

        partial void OnIdpEriodChanging(int value);

        partial void OnScpcHargedChanged();

        partial void OnScpcHargedChanging(sbyte value);

        partial void OnScphOursChanged();

        partial void OnScphOursChanging(System.Nullable<decimal> value);

        partial void OnSCPtChanged();

        partial void OnSCPtChanging(string value);

        partial void OnScptIcketChanged();

        partial void OnScptIcketChanging(string value);

        partial void OnStartHourChanged();

        partial void OnStartHourChanging(System.DateTime value);

        partial void OnTChanged();

        partial void OnTChanging(string value);

        partial void OnTicketChanged();

        partial void OnTicketChanging(string value);
        #endregion


        public ExcelRow()
        {
            this.OnCreated();
        }

        [Column(Storage = "_date", Name = "Date", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                if ((_date != value))
                {
                    this.OnDateChanging(value);
                    this.SendPropertyChanging();
                    this._date = value;
                    this.SendPropertyChanged("Date");
                    this.OnDateChanged();
                }
            }
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(4000)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_endHour", Name = "EndHour", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> EndHour
        {
            get
            {
                return this._endHour;
            }
            set
            {
                if ((_endHour != value))
                {
                    this.OnEndHourChanging(value);
                    this.SendPropertyChanging();
                    this._endHour = value;
                    this.SendPropertyChanged("EndHour");
                    this.OnEndHourChanged();
                }
            }
        }

        [Column(Storage = "_ideXcelRow", Name = "IDExcelRow", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdeXcelRow
        {
            get
            {
                return this._ideXcelRow;
            }
            set
            {
                if ((_ideXcelRow != value))
                {
                    this.OnIdeXcelRowChanging(value);
                    this.SendPropertyChanging();
                    this._ideXcelRow = value;
                    this.SendPropertyChanged("IdeXcelRow");
                    this.OnIdeXcelRowChanged();
                }
            }
        }

        [Column(Storage = "_idpEriod", Name = "IDPeriod", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdpEriod
        {
            get
            {
                return this._idpEriod;
            }
            set
            {
                if ((_idpEriod != value))
                {
                    this.OnIdpEriodChanging(value);
                    this.SendPropertyChanging();
                    this._idpEriod = value;
                    this.SendPropertyChanged("IdpEriod");
                    this.OnIdpEriodChanged();
                }
            }
        }

        [Column(Storage = "_scpcHarged", Name = "SCPCharged", DbType = "tinyint(1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public sbyte ScpcHarged
        {
            get
            {
                return this._scpcHarged;
            }
            set
            {
                if ((_scpcHarged != value))
                {
                    this.OnScpcHargedChanging(value);
                    this.SendPropertyChanging();
                    this._scpcHarged = value;
                    this.SendPropertyChanged("ScpcHarged");
                    this.OnScpcHargedChanged();
                }
            }
        }

        [Column(Storage = "_scphOurs", Name = "SCPHours", DbType = "decimal(2,1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<decimal> ScphOurs
        {
            get
            {
                return this._scphOurs;
            }
            set
            {
                if ((_scphOurs != value))
                {
                    this.OnScphOursChanging(value);
                    this.SendPropertyChanging();
                    this._scphOurs = value;
                    this.SendPropertyChanged("ScphOurs");
                    this.OnScphOursChanged();
                }
            }
        }

        [Column(Storage = "_scpT", Name = "SCPT", DbType = "varchar(6)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string SCPt
        {
            get
            {
                return this._scpT;
            }
            set
            {
                if (((_scpT == value)
                            == false))
                {
                    this.OnSCPtChanging(value);
                    this.SendPropertyChanging();
                    this._scpT = value;
                    this.SendPropertyChanged("SCPt");
                    this.OnSCPtChanged();
                }
            }
        }

        [Column(Storage = "_scptIcket", Name = "SCPTicket", DbType = "varchar(13)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ScptIcket
        {
            get
            {
                return this._scptIcket;
            }
            set
            {
                if (((_scptIcket == value)
                            == false))
                {
                    this.OnScptIcketChanging(value);
                    this.SendPropertyChanging();
                    this._scptIcket = value;
                    this.SendPropertyChanged("ScptIcket");
                    this.OnScptIcketChanged();
                }
            }
        }

        [Column(Storage = "_startHour", Name = "StartHour", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime StartHour
        {
            get
            {
                return this._startHour;
            }
            set
            {
                if ((_startHour != value))
                {
                    this.OnStartHourChanging(value);
                    this.SendPropertyChanging();
                    this._startHour = value;
                    this.SendPropertyChanged("StartHour");
                    this.OnStartHourChanged();
                }
            }
        }

        [Column(Storage = "_t", Name = "T", DbType = "varchar(6)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string T
        {
            get
            {
                return this._t;
            }
            set
            {
                if (((_t == value)
                            == false))
                {
                    if (_resource1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTChanging(value);
                    this.SendPropertyChanging();
                    this._t = value;
                    this.SendPropertyChanged("T");
                    this.OnTChanged();
                }
            }
        }

        [Column(Storage = "_ticket", Name = "Ticket", DbType = "varchar(15)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Ticket
        {
            get
            {
                return this._ticket;
            }
            set
            {
                if (((_ticket == value)
                            == false))
                {
                    this.OnTicketChanging(value);
                    this.SendPropertyChanging();
                    this._ticket = value;
                    this.SendPropertyChanged("Ticket");
                    this.OnTicketChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_period", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_ExcelRow_Period", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Period Period
        {
            get
            {
                return this._period.Entity;
            }
            set
            {
                if (((this._period.Entity == value)
                            == false))
                {
                    if ((this._period.Entity != null))
                    {
                        Period previousPeriod = this._period.Entity;
                        this._period.Entity = null;
                        previousPeriod.ExcelRow.Remove(this);
                    }
                    this._period.Entity = value;
                    if ((value != null))
                    {
                        value.ExcelRow.Add(this);
                        _idpEriod = value.IdpEriod;
                    }
                    else
                    {
                        _idpEriod = default(int);
                    }
                }
            }
        }

        [Association(Storage = "_resource", OtherKey = "T", ThisKey = "SCPt", Name = "fk_ExcelRow_SCPT", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Resource Resource
        {
            get
            {
                return this._resource.Entity;
            }
            set
            {
                if (((this._resource.Entity == value)
                            == false))
                {
                    if ((this._resource.Entity != null))
                    {
                        Resource previousResource = this._resource.Entity;
                        this._resource.Entity = null;
                        previousResource.ExcelRow.Remove(this);
                    }
                    this._resource.Entity = value;
                    if ((value != null))
                    {
                        value.ExcelRow.Add(this);
                        _scpT = value.T;
                    }
                    else
                    {
                        _scpT = null;
                    }
                }
            }
        }

        [Association(Storage = "_ticketTicket", OtherKey = "Number", ThisKey = "ScptIcket", Name = "fk_ExcelRow_SCPTicket", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Ticket TicketTicket
        {
            get
            {
                return this._ticketTicket.Entity;
            }
            set
            {
                if (((this._ticketTicket.Entity == value)
                            == false))
                {
                    if ((this._ticketTicket.Entity != null))
                    {
                        Ticket previousTicket = this._ticketTicket.Entity;
                        this._ticketTicket.Entity = null;
                        previousTicket.ExcelRow.Remove(this);
                    }
                    this._ticketTicket.Entity = value;
                    if ((value != null))
                    {
                        value.ExcelRow.Add(this);
                        _scptIcket = value.Number;
                    }
                    else
                    {
                        _scptIcket = null;
                    }
                }
            }
        }

        [Association(Storage = "_resource1", OtherKey = "T", ThisKey = "T", Name = "fk_ExcelRow_T", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Resource Resource1
        {
            get
            {
                return this._resource1.Entity;
            }
            set
            {
                if (((this._resource1.Entity == value)
                            == false))
                {
                    if ((this._resource1.Entity != null))
                    {
                        Resource previousResource = this._resource1.Entity;
                        this._resource1.Entity = null;
                        previousResource.ExcelRow1.Remove(this);
                    }
                    this._resource1.Entity = value;
                    if ((value != null))
                    {
                        value.ExcelRow1.Add(this);
                        _t = value.T;
                    }
                    else
                    {
                        _t = default(string);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "swt.holiday")]
    public partial class Holiday : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _date;

        private string _description;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);
        #endregion


        public Holiday()
        {
            this.OnCreated();
        }

        [Column(Storage = "_date", Name = "Date", DbType = "datetime", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                if ((_date != value))
                {
                    this.OnDateChanging(value);
                    this.SendPropertyChanging();
                    this._date = value;
                    this.SendPropertyChanged("Date");
                    this.OnDateChanged();
                }
            }
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(100)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "swt.period")]
    public partial class Period : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _description;

        private System.Nullable<System.DateTime> _endDate;

        private int _idpEriod;

        private int _month;

        private System.DateTime _startDate;

        private int _year;

        private EntitySet<ExcelRow> _excelRow;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnEndDateChanged();

        partial void OnEndDateChanging(System.Nullable<System.DateTime> value);

        partial void OnIdpEriodChanged();

        partial void OnIdpEriodChanging(int value);

        partial void OnMonthChanged();

        partial void OnMonthChanging(int value);

        partial void OnStartDateChanged();

        partial void OnStartDateChanging(System.DateTime value);

        partial void OnYearChanged();

        partial void OnYearChanging(int value);
        #endregion


        public Period()
        {
            _excelRow = new EntitySet<ExcelRow>(new Action<ExcelRow>(this.ExcelRow_Attach), new Action<ExcelRow>(this.ExcelRow_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(20)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_endDate", Name = "EndDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                if ((_endDate != value))
                {
                    this.OnEndDateChanging(value);
                    this.SendPropertyChanging();
                    this._endDate = value;
                    this.SendPropertyChanged("EndDate");
                    this.OnEndDateChanged();
                }
            }
        }

        [Column(Storage = "_idpEriod", Name = "IDPeriod", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdpEriod
        {
            get
            {
                return this._idpEriod;
            }
            set
            {
                if ((_idpEriod != value))
                {
                    this.OnIdpEriodChanging(value);
                    this.SendPropertyChanging();
                    this._idpEriod = value;
                    this.SendPropertyChanged("IdpEriod");
                    this.OnIdpEriodChanged();
                }
            }
        }

        [Column(Storage = "_month", Name = "Month", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Month
        {
            get
            {
                return this._month;
            }
            set
            {
                if ((_month != value))
                {
                    this.OnMonthChanging(value);
                    this.SendPropertyChanging();
                    this._month = value;
                    this.SendPropertyChanged("Month");
                    this.OnMonthChanged();
                }
            }
        }

        [Column(Storage = "_startDate", Name = "StartDate", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                if ((_startDate != value))
                {
                    this.OnStartDateChanging(value);
                    this.SendPropertyChanging();
                    this._startDate = value;
                    this.SendPropertyChanged("StartDate");
                    this.OnStartDateChanged();
                }
            }
        }

        [Column(Storage = "_year", Name = "Year", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Year
        {
            get
            {
                return this._year;
            }
            set
            {
                if ((_year != value))
                {
                    this.OnYearChanging(value);
                    this.SendPropertyChanging();
                    this._year = value;
                    this.SendPropertyChanged("Year");
                    this.OnYearChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_excelRow", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_ExcelRow_Period")]
        [DebuggerNonUserCode()]
        public EntitySet<ExcelRow> ExcelRow
        {
            get
            {
                return this._excelRow;
            }
            set
            {
                this._excelRow = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void ExcelRow_Attach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Period = this;
        }

        private void ExcelRow_Detach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Period = null;
        }
        #endregion
    }

    [Table(Name = "swt.resource")]
    public partial class Resource : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _defaultCluster;

        private string _name;

        private string _t;

        private EntitySet<ExcelRow> _excelRow;

        private EntitySet<ExcelRow> _excelRow1;

        private EntitySet<Ticket> _ticket;

        private EntityRef<Cluster> _cluster = new EntityRef<Cluster>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDefaultClusterChanged();

        partial void OnDefaultClusterChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnTChanged();

        partial void OnTChanging(string value);
        #endregion


        public Resource()
        {
            _excelRow = new EntitySet<ExcelRow>(new Action<ExcelRow>(this.ExcelRow_Attach), new Action<ExcelRow>(this.ExcelRow_Detach));
            _excelRow1 = new EntitySet<ExcelRow>(new Action<ExcelRow>(this.ExcelRow1_Attach), new Action<ExcelRow>(this.ExcelRow1_Detach));
            _ticket = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket_Attach), new Action<Ticket>(this.Ticket_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_defaultCluster", Name = "DefaultCluster", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int DefaultCluster
        {
            get
            {
                return this._defaultCluster;
            }
            set
            {
                if ((_defaultCluster != value))
                {
                    if (_cluster.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnDefaultClusterChanging(value);
                    this.SendPropertyChanging();
                    this._defaultCluster = value;
                    this.SendPropertyChanged("DefaultCluster");
                    this.OnDefaultClusterChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "Name", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value)
                            == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_t", Name = "T", DbType = "varchar(6)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string T
        {
            get
            {
                return this._t;
            }
            set
            {
                if (((_t == value)
                            == false))
                {
                    this.OnTChanging(value);
                    this.SendPropertyChanging();
                    this._t = value;
                    this.SendPropertyChanged("T");
                    this.OnTChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_excelRow", OtherKey = "SCPt", ThisKey = "T", Name = "fk_ExcelRow_SCPT")]
        [DebuggerNonUserCode()]
        public EntitySet<ExcelRow> ExcelRow
        {
            get
            {
                return this._excelRow;
            }
            set
            {
                this._excelRow = value;
            }
        }

        [Association(Storage = "_excelRow1", OtherKey = "T", ThisKey = "T", Name = "fk_ExcelRow_T")]
        [DebuggerNonUserCode()]
        public EntitySet<ExcelRow> ExcelRow1
        {
            get
            {
                return this._excelRow1;
            }
            set
            {
                this._excelRow1 = value;
            }
        }

        [Association(Storage = "_ticket", OtherKey = "AssignedTo", ThisKey = "T", Name = "fk_Ticket_AssignedTo")]
        [DebuggerNonUserCode()]
        public EntitySet<Ticket> Ticket
        {
            get
            {
                return this._ticket;
            }
            set
            {
                this._ticket = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_cluster", OtherKey = "IdcLuster", ThisKey = "DefaultCluster", Name = "fk_Res_Cluster", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Cluster Cluster
        {
            get
            {
                return this._cluster.Entity;
            }
            set
            {
                if (((this._cluster.Entity == value)
                            == false))
                {
                    if ((this._cluster.Entity != null))
                    {
                        Cluster previousCluster = this._cluster.Entity;
                        this._cluster.Entity = null;
                        previousCluster.Resource.Remove(this);
                    }
                    this._cluster.Entity = value;
                    if ((value != null))
                    {
                        value.Resource.Add(this);
                        _defaultCluster = value.IdcLuster;
                    }
                    else
                    {
                        _defaultCluster = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void ExcelRow_Attach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Resource = this;
        }

        private void ExcelRow_Detach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Resource = null;
        }

        private void ExcelRow1_Attach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Resource1 = this;
        }

        private void ExcelRow1_Detach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.Resource1 = null;
        }

        private void Ticket_Attach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Resource = this;
        }

        private void Ticket_Detach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Resource = null;
        }
        #endregion
    }

    [Table(Name = "swt.roles")]
    public partial class Roles : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _applicationName;

        private string _roleName;

        private EntitySet<UsersInRoles> _usersInRoles;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationNameChanged();

        partial void OnApplicationNameChanging(string value);

        partial void OnRoleNameChanged();

        partial void OnRoleNameChanging(string value);
        #endregion


        public Roles()
        {
            _usersInRoles = new EntitySet<UsersInRoles>(new Action<UsersInRoles>(this.UsersInRoles_Attach), new Action<UsersInRoles>(this.UsersInRoles_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_applicationName", Name = "ApplicationName", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string ApplicationName
        {
            get
            {
                return this._applicationName;
            }
            set
            {
                if (((_applicationName == value)
                            == false))
                {
                    this.OnApplicationNameChanging(value);
                    this.SendPropertyChanging();
                    this._applicationName = value;
                    this.SendPropertyChanged("ApplicationName");
                    this.OnApplicationNameChanged();
                }
            }
        }

        [Column(Storage = "_roleName", Name = "RoleName", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string RoleName
        {
            get
            {
                return this._roleName;
            }
            set
            {
                if (((_roleName == value)
                            == false))
                {
                    this.OnRoleNameChanging(value);
                    this.SendPropertyChanging();
                    this._roleName = value;
                    this.SendPropertyChanged("RoleName");
                    this.OnRoleNameChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_usersInRoles", OtherKey = "ApplicationName,RoleName", ThisKey = "ApplicationName,RoleName", Name = "fk_UsersInRoles_roles")]
        [DebuggerNonUserCode()]
        public EntitySet<UsersInRoles> UsersInRoles
        {
            get
            {
                return this._usersInRoles;
            }
            set
            {
                this._usersInRoles = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void UsersInRoles_Attach(UsersInRoles entity)
        {
            this.SendPropertyChanging();
            entity.Roles = this;
        }

        private void UsersInRoles_Detach(UsersInRoles entity)
        {
            this.SendPropertyChanging();
            entity.Roles = null;
        }
        #endregion
    }

    [Table(Name = "swt.task")]
    public partial class Task : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _description;

        private System.Nullable<int> _donePercentage;

        private System.Nullable<decimal> _estimatedHours;

        private int _idtAsk;

        private int _phase;

        private int _taskNumber;

        private string _ticketNumber;

        private EntityRef<Ticket> _ticket = new EntityRef<Ticket>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnDonePercentageChanged();

        partial void OnDonePercentageChanging(System.Nullable<int> value);

        partial void OnEstimatedHoursChanged();

        partial void OnEstimatedHoursChanging(System.Nullable<decimal> value);

        partial void OnIdtAskChanged();

        partial void OnIdtAskChanging(int value);

        partial void OnPhaseChanged();

        partial void OnPhaseChanging(int value);

        partial void OnTaskNumberChanged();

        partial void OnTaskNumberChanging(int value);

        partial void OnTicketNumberChanged();

        partial void OnTicketNumberChanging(string value);
        #endregion


        public Task()
        {
            this.OnCreated();
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_donePercentage", Name = "DonePercentage", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> DonePercentage
        {
            get
            {
                return this._donePercentage;
            }
            set
            {
                if ((_donePercentage != value))
                {
                    this.OnDonePercentageChanging(value);
                    this.SendPropertyChanging();
                    this._donePercentage = value;
                    this.SendPropertyChanged("DonePercentage");
                    this.OnDonePercentageChanged();
                }
            }
        }

        [Column(Storage = "_estimatedHours", Name = "EstimatedHours", DbType = "decimal(2,1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<decimal> EstimatedHours
        {
            get
            {
                return this._estimatedHours;
            }
            set
            {
                if ((_estimatedHours != value))
                {
                    this.OnEstimatedHoursChanging(value);
                    this.SendPropertyChanging();
                    this._estimatedHours = value;
                    this.SendPropertyChanged("EstimatedHours");
                    this.OnEstimatedHoursChanged();
                }
            }
        }

        [Column(Storage = "_idtAsk", Name = "IDTask", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdtAsk
        {
            get
            {
                return this._idtAsk;
            }
            set
            {
                if ((_idtAsk != value))
                {
                    this.OnIdtAskChanging(value);
                    this.SendPropertyChanging();
                    this._idtAsk = value;
                    this.SendPropertyChanged("IdtAsk");
                    this.OnIdtAskChanged();
                }
            }
        }

        [Column(Storage = "_phase", Name = "Phase", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Phase
        {
            get
            {
                return this._phase;
            }
            set
            {
                if ((_phase != value))
                {
                    this.OnPhaseChanging(value);
                    this.SendPropertyChanging();
                    this._phase = value;
                    this.SendPropertyChanged("Phase");
                    this.OnPhaseChanged();
                }
            }
        }

        [Column(Storage = "_taskNumber", Name = "TaskNumber", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int TaskNumber
        {
            get
            {
                return this._taskNumber;
            }
            set
            {
                if ((_taskNumber != value))
                {
                    this.OnTaskNumberChanging(value);
                    this.SendPropertyChanging();
                    this._taskNumber = value;
                    this.SendPropertyChanged("TaskNumber");
                    this.OnTaskNumberChanged();
                }
            }
        }

        [Column(Storage = "_ticketNumber", Name = "TicketNumber", DbType = "varchar(13)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string TicketNumber
        {
            get
            {
                return this._ticketNumber;
            }
            set
            {
                if (((_ticketNumber == value)
                            == false))
                {
                    if (_ticket.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTicketNumberChanging(value);
                    this.SendPropertyChanging();
                    this._ticketNumber = value;
                    this.SendPropertyChanged("TicketNumber");
                    this.OnTicketNumberChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_ticket", OtherKey = "Number", ThisKey = "TicketNumber", Name = "fk_Task_Ticket", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Ticket Ticket
        {
            get
            {
                return this._ticket.Entity;
            }
            set
            {
                if (((this._ticket.Entity == value)
                            == false))
                {
                    if ((this._ticket.Entity != null))
                    {
                        Ticket previousTicket = this._ticket.Entity;
                        this._ticket.Entity = null;
                        previousTicket.Task.Remove(this);
                    }
                    this._ticket.Entity = value;
                    if ((value != null))
                    {
                        value.Task.Add(this);
                        _ticketNumber = value.Number;
                    }
                    else
                    {
                        _ticketNumber = default(string);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "swt.ticket")]
    public partial class Ticket : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _assignedTo;

        private int _category;

        private decimal _consumedHours;

        private System.DateTime _dateCreate;

        private System.Nullable<System.DateTime> _dateDelete;

        private System.DateTime _dateLastModified;

        private System.Nullable<System.DateTime> _deliveryDate;

        private string _description;

        private int _idcLuster;

        private string _iduSerCreate;

        private string _iduSerDelete;

        private string _iduSerLastModified;

        private string _number;

        private int _priority;

        private System.Nullable<System.DateTime> _realDeliveryDate;

        private System.Nullable<System.DateTime> _startDate;

        private int _status;

        private string _system;

        private string _title;

        private EntitySet<ExcelRow> _excelRow;

        private EntitySet<Task> _task;

        private EntitySet<TicketComment> _ticketComment;

        private EntityRef<Resource> _resource = new EntityRef<Resource>();

        private EntityRef<Cluster> _cluster = new EntityRef<Cluster>();

        private EntityRef<Users> _users = new EntityRef<Users>();

        private EntityRef<Users> _users1 = new EntityRef<Users>();

        private EntityRef<Users> _users2 = new EntityRef<Users>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAssignedToChanged();

        partial void OnAssignedToChanging(string value);

        partial void OnCategoryChanged();

        partial void OnCategoryChanging(int value);

        partial void OnConsumedHoursChanged();

        partial void OnConsumedHoursChanging(decimal value);

        partial void OnDateCreateChanged();

        partial void OnDateCreateChanging(System.DateTime value);

        partial void OnDateDeleteChanged();

        partial void OnDateDeleteChanging(System.Nullable<System.DateTime> value);

        partial void OnDateLastModifiedChanged();

        partial void OnDateLastModifiedChanging(System.DateTime value);

        partial void OnDeliveryDateChanged();

        partial void OnDeliveryDateChanging(System.Nullable<System.DateTime> value);

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnIdcLusterChanged();

        partial void OnIdcLusterChanging(int value);

        partial void OnIduSerCreateChanged();

        partial void OnIduSerCreateChanging(string value);

        partial void OnIduSerDeleteChanged();

        partial void OnIduSerDeleteChanging(string value);

        partial void OnIduSerLastModifiedChanged();

        partial void OnIduSerLastModifiedChanging(string value);

        partial void OnNumberChanged();

        partial void OnNumberChanging(string value);

        partial void OnPriorityChanged();

        partial void OnPriorityChanging(int value);

        partial void OnRealDeliveryDateChanged();

        partial void OnRealDeliveryDateChanging(System.Nullable<System.DateTime> value);

        partial void OnStartDateChanged();

        partial void OnStartDateChanging(System.Nullable<System.DateTime> value);

        partial void OnStatusChanged();

        partial void OnStatusChanging(int value);

        partial void OnSystemChanged();

        partial void OnSystemChanging(string value);

        partial void OnTitleChanged();

        partial void OnTitleChanging(string value);
        #endregion


        public Ticket()
        {
            _excelRow = new EntitySet<ExcelRow>(new Action<ExcelRow>(this.ExcelRow_Attach), new Action<ExcelRow>(this.ExcelRow_Detach));
            _task = new EntitySet<Task>(new Action<Task>(this.Task_Attach), new Action<Task>(this.Task_Detach));
            _ticketComment = new EntitySet<TicketComment>(new Action<TicketComment>(this.TicketComment_Attach), new Action<TicketComment>(this.TicketComment_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_assignedTo", Name = "AssignedTo", DbType = "varchar(6)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string AssignedTo
        {
            get
            {
                return this._assignedTo;
            }
            set
            {
                if (((_assignedTo == value)
                            == false))
                {
                    if (_resource.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAssignedToChanging(value);
                    this.SendPropertyChanging();
                    this._assignedTo = value;
                    this.SendPropertyChanged("AssignedTo");
                    this.OnAssignedToChanged();
                }
            }
        }

        [Column(Storage = "_category", Name = "Category", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Category
        {
            get
            {
                return this._category;
            }
            set
            {
                if ((_category != value))
                {
                    this.OnCategoryChanging(value);
                    this.SendPropertyChanging();
                    this._category = value;
                    this.SendPropertyChanged("Category");
                    this.OnCategoryChanged();
                }
            }
        }

        [Column(Storage = "_consumedHours", Name = "ConsumedHours", DbType = "decimal(4,1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public decimal ConsumedHours
        {
            get
            {
                return this._consumedHours;
            }
            set
            {
                if ((_consumedHours != value))
                {
                    this.OnConsumedHoursChanging(value);
                    this.SendPropertyChanging();
                    this._consumedHours = value;
                    this.SendPropertyChanged("ConsumedHours");
                    this.OnConsumedHoursChanged();
                }
            }
        }

        [Column(Storage = "_dateCreate", Name = "DateCreate", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime DateCreate
        {
            get
            {
                return this._dateCreate;
            }
            set
            {
                if ((_dateCreate != value))
                {
                    this.OnDateCreateChanging(value);
                    this.SendPropertyChanging();
                    this._dateCreate = value;
                    this.SendPropertyChanged("DateCreate");
                    this.OnDateCreateChanged();
                }
            }
        }

        [Column(Storage = "_dateDelete", Name = "DateDelete", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> DateDelete
        {
            get
            {
                return this._dateDelete;
            }
            set
            {
                if ((_dateDelete != value))
                {
                    this.OnDateDeleteChanging(value);
                    this.SendPropertyChanging();
                    this._dateDelete = value;
                    this.SendPropertyChanged("DateDelete");
                    this.OnDateDeleteChanged();
                }
            }
        }

        [Column(Storage = "_dateLastModified", Name = "DateLastModified", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime DateLastModified
        {
            get
            {
                return this._dateLastModified;
            }
            set
            {
                if ((_dateLastModified != value))
                {
                    this.OnDateLastModifiedChanging(value);
                    this.SendPropertyChanging();
                    this._dateLastModified = value;
                    this.SendPropertyChanged("DateLastModified");
                    this.OnDateLastModifiedChanged();
                }
            }
        }

        [Column(Storage = "_deliveryDate", Name = "DeliveryDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> DeliveryDate
        {
            get
            {
                return this._deliveryDate;
            }
            set
            {
                if ((_deliveryDate != value))
                {
                    this.OnDeliveryDateChanging(value);
                    this.SendPropertyChanging();
                    this._deliveryDate = value;
                    this.SendPropertyChanged("DeliveryDate");
                    this.OnDeliveryDateChanged();
                }
            }
        }

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(4000)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value)
                            == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_idcLuster", Name = "IDCluster", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdcLuster
        {
            get
            {
                return this._idcLuster;
            }
            set
            {
                if ((_idcLuster != value))
                {
                    this.OnIdcLusterChanging(value);
                    this.SendPropertyChanging();
                    this._idcLuster = value;
                    this.SendPropertyChanged("IdcLuster");
                    this.OnIdcLusterChanged();
                }
            }
        }

        [Column(Storage = "_iduSerCreate", Name = "IDUserCreate", DbType = "varchar(36)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IduSerCreate
        {
            get
            {
                return this._iduSerCreate;
            }
            set
            {
                if (((_iduSerCreate == value)
                            == false))
                {
                    this.OnIduSerCreateChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerCreate = value;
                    this.SendPropertyChanged("IduSerCreate");
                    this.OnIduSerCreateChanged();
                }
            }
        }

        [Column(Storage = "_iduSerDelete", Name = "IDUserDelete", DbType = "varchar(36)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string IduSerDelete
        {
            get
            {
                return this._iduSerDelete;
            }
            set
            {
                if (((_iduSerDelete == value)
                            == false))
                {
                    this.OnIduSerDeleteChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerDelete = value;
                    this.SendPropertyChanged("IduSerDelete");
                    this.OnIduSerDeleteChanged();
                }
            }
        }

        [Column(Storage = "_iduSerLastModified", Name = "IDUserLastModified", DbType = "varchar(36)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IduSerLastModified
        {
            get
            {
                return this._iduSerLastModified;
            }
            set
            {
                if (((_iduSerLastModified == value)
                            == false))
                {
                    this.OnIduSerLastModifiedChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerLastModified = value;
                    this.SendPropertyChanged("IduSerLastModified");
                    this.OnIduSerLastModifiedChanged();
                }
            }
        }

        [Column(Storage = "_number", Name = "Number", DbType = "varchar(13)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if (((_number == value)
                            == false))
                {
                    this.OnNumberChanging(value);
                    this.SendPropertyChanging();
                    this._number = value;
                    this.SendPropertyChanged("Number");
                    this.OnNumberChanged();
                }
            }
        }

        [Column(Storage = "_priority", Name = "Priority", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                if ((_priority != value))
                {
                    this.OnPriorityChanging(value);
                    this.SendPropertyChanging();
                    this._priority = value;
                    this.SendPropertyChanged("Priority");
                    this.OnPriorityChanged();
                }
            }
        }

        [Column(Storage = "_realDeliveryDate", Name = "RealDeliveryDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> RealDeliveryDate
        {
            get
            {
                return this._realDeliveryDate;
            }
            set
            {
                if ((_realDeliveryDate != value))
                {
                    this.OnRealDeliveryDateChanging(value);
                    this.SendPropertyChanging();
                    this._realDeliveryDate = value;
                    this.SendPropertyChanged("RealDeliveryDate");
                    this.OnRealDeliveryDateChanged();
                }
            }
        }

        [Column(Storage = "_startDate", Name = "StartDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                if ((_startDate != value))
                {
                    this.OnStartDateChanging(value);
                    this.SendPropertyChanging();
                    this._startDate = value;
                    this.SendPropertyChanged("StartDate");
                    this.OnStartDateChanged();
                }
            }
        }

        [Column(Storage = "_status", Name = "Status", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if ((_status != value))
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
                }
            }
        }

        [Column(Storage = "_system", Name = "System", DbType = "varchar(45)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string System
        {
            get
            {
                return this._system;
            }
            set
            {
                if (((_system == value)
                            == false))
                {
                    this.OnSystemChanging(value);
                    this.SendPropertyChanging();
                    this._system = value;
                    this.SendPropertyChanged("System");
                    this.OnSystemChanged();
                }
            }
        }

        [Column(Storage = "_title", Name = "Title", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (((_title == value)
                            == false))
                {
                    this.OnTitleChanging(value);
                    this.SendPropertyChanging();
                    this._title = value;
                    this.SendPropertyChanged("Title");
                    this.OnTitleChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_excelRow", OtherKey = "ScptIcket", ThisKey = "Number", Name = "fk_ExcelRow_SCPTicket")]
        [DebuggerNonUserCode()]
        public EntitySet<ExcelRow> ExcelRow
        {
            get
            {
                return this._excelRow;
            }
            set
            {
                this._excelRow = value;
            }
        }

        [Association(Storage = "_task", OtherKey = "TicketNumber", ThisKey = "Number", Name = "fk_Task_Ticket")]
        [DebuggerNonUserCode()]
        public EntitySet<Task> Task
        {
            get
            {
                return this._task;
            }
            set
            {
                this._task = value;
            }
        }

        [Association(Storage = "_ticketComment", OtherKey = "Number", ThisKey = "Number", Name = "fk_TicketComment_Ticket")]
        [DebuggerNonUserCode()]
        public EntitySet<TicketComment> TicketComment
        {
            get
            {
                return this._ticketComment;
            }
            set
            {
                this._ticketComment = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_resource", OtherKey = "T", ThisKey = "AssignedTo", Name = "fk_Ticket_AssignedTo", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Resource Resource
        {
            get
            {
                return this._resource.Entity;
            }
            set
            {
                if (((this._resource.Entity == value)
                            == false))
                {
                    if ((this._resource.Entity != null))
                    {
                        Resource previousResource = this._resource.Entity;
                        this._resource.Entity = null;
                        previousResource.Ticket.Remove(this);
                    }
                    this._resource.Entity = value;
                    if ((value != null))
                    {
                        value.Ticket.Add(this);
                        _assignedTo = value.T;
                    }
                    else
                    {
                        _assignedTo = null;
                    }
                }
            }
        }

        [Association(Storage = "_cluster", OtherKey = "IdcLuster", ThisKey = "IdcLuster", Name = "fk_Ticket_Cluster", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Cluster Cluster
        {
            get
            {
                return this._cluster.Entity;
            }
            set
            {
                if (((this._cluster.Entity == value)
                            == false))
                {
                    if ((this._cluster.Entity != null))
                    {
                        Cluster previousCluster = this._cluster.Entity;
                        this._cluster.Entity = null;
                        previousCluster.Ticket.Remove(this);
                    }
                    this._cluster.Entity = value;
                    if ((value != null))
                    {
                        value.Ticket.Add(this);
                        _idcLuster = value.IdcLuster;
                    }
                    else
                    {
                        _idcLuster = default(int);
                    }
                }
            }
        }

        [Association(Storage = "_users", OtherKey = "PKid", ThisKey = "IduSerCreate", Name = "fk_Ticket_UserCreate", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Users Users
        {
            get
            {
                return this._users.Entity;
            }
            set
            {
                if (((this._users.Entity == value)
                            == false))
                {
                    if ((this._users.Entity != null))
                    {
                        Users previousUsers = this._users.Entity;
                        this._users.Entity = null;
                        previousUsers.Ticket.Remove(this);
                    }
                    this._users.Entity = value;
                    if ((value != null))
                    {
                        value.Ticket.Add(this);
                        _iduSerCreate = value.PKid;
                    }
                    else
                    {
                        _iduSerCreate = default(string);
                    }
                }
            }
        }

        [Association(Storage = "_users1", OtherKey = "PKid", ThisKey = "IduSerDelete", Name = "fk_Ticket_UserDelete", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Users Users1
        {
            get
            {
                return this._users1.Entity;
            }
            set
            {
                if (((this._users1.Entity == value)
                            == false))
                {
                    if ((this._users1.Entity != null))
                    {
                        Users previousUsers = this._users1.Entity;
                        this._users1.Entity = null;
                        previousUsers.Ticket1.Remove(this);
                    }
                    this._users1.Entity = value;
                    if ((value != null))
                    {
                        value.Ticket1.Add(this);
                        _iduSerDelete = value.PKid;
                    }
                    else
                    {
                        _iduSerDelete = null;
                    }
                }
            }
        }

        [Association(Storage = "_users2", OtherKey = "PKid", ThisKey = "IduSerLastModified", Name = "fk_Ticket_UserLastModified", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Users Users2
        {
            get
            {
                return this._users2.Entity;
            }
            set
            {
                if (((this._users2.Entity == value)
                            == false))
                {
                    if ((this._users2.Entity != null))
                    {
                        Users previousUsers = this._users2.Entity;
                        this._users2.Entity = null;
                        previousUsers.Ticket2.Remove(this);
                    }
                    this._users2.Entity = value;
                    if ((value != null))
                    {
                        value.Ticket2.Add(this);
                        _iduSerLastModified = value.PKid;
                    }
                    else
                    {
                        _iduSerLastModified = default(string);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void ExcelRow_Attach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.TicketTicket = this;
        }

        private void ExcelRow_Detach(ExcelRow entity)
        {
            this.SendPropertyChanging();
            entity.TicketTicket = null;
        }

        private void Task_Attach(Task entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = this;
        }

        private void Task_Detach(Task entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = null;
        }

        private void TicketComment_Attach(TicketComment entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = this;
        }

        private void TicketComment_Detach(TicketComment entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = null;
        }
        #endregion
    }

    [Table(Name = "swt.ticketcomment")]
    public partial class TicketComment : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _comment;

        private System.DateTime _date;

        private int _idtIcketComment;

        private string _iduSer;

        private string _number;

        private EntityRef<Ticket> _ticket = new EntityRef<Ticket>();

        private EntityRef<Users> _users = new EntityRef<Users>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCommentChanged();

        partial void OnCommentChanging(string value);

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnIdtIcketCommentChanged();

        partial void OnIdtIcketCommentChanging(int value);

        partial void OnIduSerChanged();

        partial void OnIduSerChanging(string value);

        partial void OnNumberChanged();

        partial void OnNumberChanging(string value);
        #endregion


        public TicketComment()
        {
            this.OnCreated();
        }

        [Column(Storage = "_comment", Name = "Comment", DbType = "varchar(4000)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                if (((_comment == value)
                            == false))
                {
                    this.OnCommentChanging(value);
                    this.SendPropertyChanging();
                    this._comment = value;
                    this.SendPropertyChanged("Comment");
                    this.OnCommentChanged();
                }
            }
        }

        [Column(Storage = "_date", Name = "Date", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                if ((_date != value))
                {
                    this.OnDateChanging(value);
                    this.SendPropertyChanging();
                    this._date = value;
                    this.SendPropertyChanged("Date");
                    this.OnDateChanged();
                }
            }
        }

        [Column(Storage = "_idtIcketComment", Name = "IDTicketComment", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdtIcketComment
        {
            get
            {
                return this._idtIcketComment;
            }
            set
            {
                if ((_idtIcketComment != value))
                {
                    this.OnIdtIcketCommentChanging(value);
                    this.SendPropertyChanging();
                    this._idtIcketComment = value;
                    this.SendPropertyChanged("IdtIcketComment");
                    this.OnIdtIcketCommentChanged();
                }
            }
        }

        [Column(Storage = "_iduSer", Name = "IDUser", DbType = "varchar(36)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IduSer
        {
            get
            {
                return this._iduSer;
            }
            set
            {
                if (((_iduSer == value)
                            == false))
                {
                    this.OnIduSerChanging(value);
                    this.SendPropertyChanging();
                    this._iduSer = value;
                    this.SendPropertyChanged("IduSer");
                    this.OnIduSerChanged();
                }
            }
        }

        [Column(Storage = "_number", Name = "Number", DbType = "varchar(13)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if (((_number == value)
                            == false))
                {
                    if (_ticket.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnNumberChanging(value);
                    this.SendPropertyChanging();
                    this._number = value;
                    this.SendPropertyChanged("Number");
                    this.OnNumberChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_ticket", OtherKey = "Number", ThisKey = "Number", Name = "fk_TicketComment_Ticket", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Ticket Ticket
        {
            get
            {
                return this._ticket.Entity;
            }
            set
            {
                if (((this._ticket.Entity == value)
                            == false))
                {
                    if ((this._ticket.Entity != null))
                    {
                        Ticket previousTicket = this._ticket.Entity;
                        this._ticket.Entity = null;
                        previousTicket.TicketComment.Remove(this);
                    }
                    this._ticket.Entity = value;
                    if ((value != null))
                    {
                        value.TicketComment.Add(this);
                        _number = value.Number;
                    }
                    else
                    {
                        _number = default(string);
                    }
                }
            }
        }

        [Association(Storage = "_users", OtherKey = "PKid", ThisKey = "IduSer", Name = "fk_TicketComment_User", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Users Users
        {
            get
            {
                return this._users.Entity;
            }
            set
            {
                if (((this._users.Entity == value)
                            == false))
                {
                    if ((this._users.Entity != null))
                    {
                        Users previousUsers = this._users.Entity;
                        this._users.Entity = null;
                        previousUsers.TicketComment.Remove(this);
                    }
                    this._users.Entity = value;
                    if ((value != null))
                    {
                        value.TicketComment.Add(this);
                        _iduSer = value.PKid;
                    }
                    else
                    {
                        _iduSer = default(string);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name = "swt.users")]
    public partial class Users : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _applicationName;

        private string _comment;

        private System.Nullable<System.DateTime> _creationDate;

        private string _email;

        private System.Nullable<int> _failedPasswordAnswerAttemptCount;

        private System.Nullable<System.DateTime> _failedPasswordAnswerAttemptWindowStart;

        private System.Nullable<int> _failedPasswordAttemptCount;

        private System.Nullable<System.DateTime> _failedPasswordAttemptWindowStart;

        private System.Nullable<sbyte> _isApproved;

        private System.Nullable<sbyte> _isLockedOut;

        private System.Nullable<sbyte> _isOnline;

        private System.Nullable<System.DateTime> _lastActivityDate;

        private System.Nullable<System.DateTime> _lastLockedOutDate;

        private System.Nullable<System.DateTime> _lastLoginDate;

        private System.Nullable<System.DateTime> _lastPasswordChangeDate;

        private string _password;

        private string _passwordAnswer;

        private string _passwordQuestion;

        private string _pkID;

        private string _username;

        private EntitySet<TicketComment> _ticketComment;

        private EntitySet<Ticket> _ticket;

        private EntitySet<Ticket> _ticket1;

        private EntitySet<Ticket> _ticket2;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationNameChanged();

        partial void OnApplicationNameChanging(string value);

        partial void OnCommentChanged();

        partial void OnCommentChanging(string value);

        partial void OnCreationDateChanged();

        partial void OnCreationDateChanging(System.Nullable<System.DateTime> value);

        partial void OnEmailChanged();

        partial void OnEmailChanging(string value);

        partial void OnFailedPasswordAnswerAttemptCountChanged();

        partial void OnFailedPasswordAnswerAttemptCountChanging(System.Nullable<int> value);

        partial void OnFailedPasswordAnswerAttemptWindowStartChanged();

        partial void OnFailedPasswordAnswerAttemptWindowStartChanging(System.Nullable<System.DateTime> value);

        partial void OnFailedPasswordAttemptCountChanged();

        partial void OnFailedPasswordAttemptCountChanging(System.Nullable<int> value);

        partial void OnFailedPasswordAttemptWindowStartChanged();

        partial void OnFailedPasswordAttemptWindowStartChanging(System.Nullable<System.DateTime> value);

        partial void OnIsApprovedChanged();

        partial void OnIsApprovedChanging(System.Nullable<sbyte> value);

        partial void OnIsLockedOutChanged();

        partial void OnIsLockedOutChanging(System.Nullable<sbyte> value);

        partial void OnIsOnlineChanged();

        partial void OnIsOnlineChanging(System.Nullable<sbyte> value);

        partial void OnLastActivityDateChanged();

        partial void OnLastActivityDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastLockedOutDateChanged();

        partial void OnLastLockedOutDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastLoginDateChanged();

        partial void OnLastLoginDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastPasswordChangeDateChanged();

        partial void OnLastPasswordChangeDateChanging(System.Nullable<System.DateTime> value);

        partial void OnPasswordChanged();

        partial void OnPasswordChanging(string value);

        partial void OnPasswordAnswerChanged();

        partial void OnPasswordAnswerChanging(string value);

        partial void OnPasswordQuestionChanged();

        partial void OnPasswordQuestionChanging(string value);

        partial void OnPKidChanged();

        partial void OnPKidChanging(string value);

        partial void OnUsernameChanged();

        partial void OnUsernameChanging(string value);
        #endregion


        public Users()
        {
            _ticketComment = new EntitySet<TicketComment>(new Action<TicketComment>(this.TicketComment_Attach), new Action<TicketComment>(this.TicketComment_Detach));
            _ticket = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket_Attach), new Action<Ticket>(this.Ticket_Detach));
            _ticket1 = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket1_Attach), new Action<Ticket>(this.Ticket1_Detach));
            _ticket2 = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket2_Attach), new Action<Ticket>(this.Ticket2_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_applicationName", Name = "ApplicationName", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string ApplicationName
        {
            get
            {
                return this._applicationName;
            }
            set
            {
                if (((_applicationName == value)
                            == false))
                {
                    this.OnApplicationNameChanging(value);
                    this.SendPropertyChanging();
                    this._applicationName = value;
                    this.SendPropertyChanged("ApplicationName");
                    this.OnApplicationNameChanged();
                }
            }
        }

        [Column(Storage = "_comment", Name = "Comment", DbType = "varchar(255)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                if (((_comment == value)
                            == false))
                {
                    this.OnCommentChanging(value);
                    this.SendPropertyChanging();
                    this._comment = value;
                    this.SendPropertyChanged("Comment");
                    this.OnCommentChanged();
                }
            }
        }

        [Column(Storage = "_creationDate", Name = "CreationDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> CreationDate
        {
            get
            {
                return this._creationDate;
            }
            set
            {
                if ((_creationDate != value))
                {
                    this.OnCreationDateChanging(value);
                    this.SendPropertyChanging();
                    this._creationDate = value;
                    this.SendPropertyChanged("CreationDate");
                    this.OnCreationDateChanged();
                }
            }
        }

        [Column(Storage = "_email", Name = "Email", DbType = "varchar(100)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (((_email == value)
                            == false))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Column(Storage = "_failedPasswordAnswerAttemptCount", Name = "FailedPasswordAnswerAttemptCount", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> FailedPasswordAnswerAttemptCount
        {
            get
            {
                return this._failedPasswordAnswerAttemptCount;
            }
            set
            {
                if ((_failedPasswordAnswerAttemptCount != value))
                {
                    this.OnFailedPasswordAnswerAttemptCountChanging(value);
                    this.SendPropertyChanging();
                    this._failedPasswordAnswerAttemptCount = value;
                    this.SendPropertyChanged("FailedPasswordAnswerAttemptCount");
                    this.OnFailedPasswordAnswerAttemptCountChanged();
                }
            }
        }

        [Column(Storage = "_failedPasswordAnswerAttemptWindowStart", Name = "FailedPasswordAnswerAttemptWindowStart", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> FailedPasswordAnswerAttemptWindowStart
        {
            get
            {
                return this._failedPasswordAnswerAttemptWindowStart;
            }
            set
            {
                if ((_failedPasswordAnswerAttemptWindowStart != value))
                {
                    this.OnFailedPasswordAnswerAttemptWindowStartChanging(value);
                    this.SendPropertyChanging();
                    this._failedPasswordAnswerAttemptWindowStart = value;
                    this.SendPropertyChanged("FailedPasswordAnswerAttemptWindowStart");
                    this.OnFailedPasswordAnswerAttemptWindowStartChanged();
                }
            }
        }

        [Column(Storage = "_failedPasswordAttemptCount", Name = "FailedPasswordAttemptCount", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> FailedPasswordAttemptCount
        {
            get
            {
                return this._failedPasswordAttemptCount;
            }
            set
            {
                if ((_failedPasswordAttemptCount != value))
                {
                    this.OnFailedPasswordAttemptCountChanging(value);
                    this.SendPropertyChanging();
                    this._failedPasswordAttemptCount = value;
                    this.SendPropertyChanged("FailedPasswordAttemptCount");
                    this.OnFailedPasswordAttemptCountChanged();
                }
            }
        }

        [Column(Storage = "_failedPasswordAttemptWindowStart", Name = "FailedPasswordAttemptWindowStart", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> FailedPasswordAttemptWindowStart
        {
            get
            {
                return this._failedPasswordAttemptWindowStart;
            }
            set
            {
                if ((_failedPasswordAttemptWindowStart != value))
                {
                    this.OnFailedPasswordAttemptWindowStartChanging(value);
                    this.SendPropertyChanging();
                    this._failedPasswordAttemptWindowStart = value;
                    this.SendPropertyChanged("FailedPasswordAttemptWindowStart");
                    this.OnFailedPasswordAttemptWindowStartChanged();
                }
            }
        }

        [Column(Storage = "_isApproved", Name = "IsApproved", DbType = "tinyint(1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> IsApproved
        {
            get
            {
                return this._isApproved;
            }
            set
            {
                if ((_isApproved != value))
                {
                    this.OnIsApprovedChanging(value);
                    this.SendPropertyChanging();
                    this._isApproved = value;
                    this.SendPropertyChanged("IsApproved");
                    this.OnIsApprovedChanged();
                }
            }
        }

        [Column(Storage = "_isLockedOut", Name = "IsLockedOut", DbType = "tinyint(1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> IsLockedOut
        {
            get
            {
                return this._isLockedOut;
            }
            set
            {
                if ((_isLockedOut != value))
                {
                    this.OnIsLockedOutChanging(value);
                    this.SendPropertyChanging();
                    this._isLockedOut = value;
                    this.SendPropertyChanged("IsLockedOut");
                    this.OnIsLockedOutChanged();
                }
            }
        }

        [Column(Storage = "_isOnline", Name = "IsOnline", DbType = "tinyint(1)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> IsOnline
        {
            get
            {
                return this._isOnline;
            }
            set
            {
                if ((_isOnline != value))
                {
                    this.OnIsOnlineChanging(value);
                    this.SendPropertyChanging();
                    this._isOnline = value;
                    this.SendPropertyChanged("IsOnline");
                    this.OnIsOnlineChanged();
                }
            }
        }

        [Column(Storage = "_lastActivityDate", Name = "LastActivityDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> LastActivityDate
        {
            get
            {
                return this._lastActivityDate;
            }
            set
            {
                if ((_lastActivityDate != value))
                {
                    this.OnLastActivityDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastActivityDate = value;
                    this.SendPropertyChanged("LastActivityDate");
                    this.OnLastActivityDateChanged();
                }
            }
        }

        [Column(Storage = "_lastLockedOutDate", Name = "LastLockedOutDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> LastLockedOutDate
        {
            get
            {
                return this._lastLockedOutDate;
            }
            set
            {
                if ((_lastLockedOutDate != value))
                {
                    this.OnLastLockedOutDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastLockedOutDate = value;
                    this.SendPropertyChanged("LastLockedOutDate");
                    this.OnLastLockedOutDateChanged();
                }
            }
        }

        [Column(Storage = "_lastLoginDate", Name = "LastLoginDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> LastLoginDate
        {
            get
            {
                return this._lastLoginDate;
            }
            set
            {
                if ((_lastLoginDate != value))
                {
                    this.OnLastLoginDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastLoginDate = value;
                    this.SendPropertyChanged("LastLoginDate");
                    this.OnLastLoginDateChanged();
                }
            }
        }

        [Column(Storage = "_lastPasswordChangeDate", Name = "LastPasswordChangeDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> LastPasswordChangeDate
        {
            get
            {
                return this._lastPasswordChangeDate;
            }
            set
            {
                if ((_lastPasswordChangeDate != value))
                {
                    this.OnLastPasswordChangeDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastPasswordChangeDate = value;
                    this.SendPropertyChanged("LastPasswordChangeDate");
                    this.OnLastPasswordChangeDateChanged();
                }
            }
        }

        [Column(Storage = "_password", Name = "Password", DbType = "varchar(128)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (((_password == value)
                            == false))
                {
                    this.OnPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._password = value;
                    this.SendPropertyChanged("Password");
                    this.OnPasswordChanged();
                }
            }
        }

        [Column(Storage = "_passwordAnswer", Name = "PasswordAnswer", DbType = "varchar(255)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PasswordAnswer
        {
            get
            {
                return this._passwordAnswer;
            }
            set
            {
                if (((_passwordAnswer == value)
                            == false))
                {
                    this.OnPasswordAnswerChanging(value);
                    this.SendPropertyChanging();
                    this._passwordAnswer = value;
                    this.SendPropertyChanged("PasswordAnswer");
                    this.OnPasswordAnswerChanged();
                }
            }
        }

        [Column(Storage = "_passwordQuestion", Name = "PasswordQuestion", DbType = "varchar(255)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PasswordQuestion
        {
            get
            {
                return this._passwordQuestion;
            }
            set
            {
                if (((_passwordQuestion == value)
                            == false))
                {
                    this.OnPasswordQuestionChanging(value);
                    this.SendPropertyChanging();
                    this._passwordQuestion = value;
                    this.SendPropertyChanged("PasswordQuestion");
                    this.OnPasswordQuestionChanged();
                }
            }
        }

        [Column(Storage = "_pkID", Name = "PKID", DbType = "varchar(36)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string PKid
        {
            get
            {
                return this._pkID;
            }
            set
            {
                if (((_pkID == value)
                            == false))
                {
                    this.OnPKidChanging(value);
                    this.SendPropertyChanging();
                    this._pkID = value;
                    this.SendPropertyChanged("PKid");
                    this.OnPKidChanged();
                }
            }
        }

        [Column(Storage = "_username", Name = "Username", DbType = "varchar(255)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                if (((_username == value)
                            == false))
                {
                    this.OnUsernameChanging(value);
                    this.SendPropertyChanging();
                    this._username = value;
                    this.SendPropertyChanged("Username");
                    this.OnUsernameChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_ticketComment", OtherKey = "IduSer", ThisKey = "PKid", Name = "fk_TicketComment_User")]
        [DebuggerNonUserCode()]
        public EntitySet<TicketComment> TicketComment
        {
            get
            {
                return this._ticketComment;
            }
            set
            {
                this._ticketComment = value;
            }
        }

        [Association(Storage = "_ticket", OtherKey = "IduSerCreate", ThisKey = "PKid", Name = "fk_Ticket_UserCreate")]
        [DebuggerNonUserCode()]
        public EntitySet<Ticket> Ticket
        {
            get
            {
                return this._ticket;
            }
            set
            {
                this._ticket = value;
            }
        }

        [Association(Storage = "_ticket1", OtherKey = "IduSerDelete", ThisKey = "PKid", Name = "fk_Ticket_UserDelete")]
        [DebuggerNonUserCode()]
        public EntitySet<Ticket> Ticket1
        {
            get
            {
                return this._ticket1;
            }
            set
            {
                this._ticket1 = value;
            }
        }

        [Association(Storage = "_ticket2", OtherKey = "IduSerLastModified", ThisKey = "PKid", Name = "fk_Ticket_UserLastModified")]
        [DebuggerNonUserCode()]
        public EntitySet<Ticket> Ticket2
        {
            get
            {
                return this._ticket2;
            }
            set
            {
                this._ticket2 = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void TicketComment_Attach(TicketComment entity)
        {
            this.SendPropertyChanging();
            entity.Users = this;
        }

        private void TicketComment_Detach(TicketComment entity)
        {
            this.SendPropertyChanging();
            entity.Users = null;
        }

        private void Ticket_Attach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users = this;
        }

        private void Ticket_Detach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users = null;
        }

        private void Ticket1_Attach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users1 = this;
        }

        private void Ticket1_Detach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users1 = null;
        }

        private void Ticket2_Attach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users2 = this;
        }

        private void Ticket2_Detach(Ticket entity)
        {
            this.SendPropertyChanging();
            entity.Users2 = null;
        }
        #endregion
    }

    [Table(Name = "swt.usersinroles")]
    public partial class UsersInRoles : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _applicationName;

        private string _roleName;

        private string _userName;

        private EntityRef<Roles> _roles = new EntityRef<Roles>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationNameChanged();

        partial void OnApplicationNameChanging(string value);

        partial void OnRoleNameChanged();

        partial void OnRoleNameChanging(string value);

        partial void OnUserNameChanged();

        partial void OnUserNameChanging(string value);
        #endregion


        public UsersInRoles()
        {
            this.OnCreated();
        }

        [Column(Storage = "_applicationName", Name = "ApplicationName", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string ApplicationName
        {
            get
            {
                return this._applicationName;
            }
            set
            {
                if (((_applicationName == value)
                            == false))
                {
                    if (_roles.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnApplicationNameChanging(value);
                    this.SendPropertyChanging();
                    this._applicationName = value;
                    this.SendPropertyChanged("ApplicationName");
                    this.OnApplicationNameChanged();
                }
            }
        }

        [Column(Storage = "_roleName", Name = "RoleName", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string RoleName
        {
            get
            {
                return this._roleName;
            }
            set
            {
                if (((_roleName == value)
                            == false))
                {
                    if (_roles.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRoleNameChanging(value);
                    this.SendPropertyChanging();
                    this._roleName = value;
                    this.SendPropertyChanged("RoleName");
                    this.OnRoleNameChanged();
                }
            }
        }

        [Column(Storage = "_userName", Name = "UserName", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (((_userName == value)
                            == false))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._userName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_roles", OtherKey = "ApplicationName,RoleName", ThisKey = "ApplicationName,RoleName", Name = "fk_UsersInRoles_roles", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public Roles Roles
        {
            get
            {
                return this._roles.Entity;
            }
            set
            {
                if (((this._roles.Entity == value)
                            == false))
                {
                    if ((this._roles.Entity != null))
                    {
                        Roles previousRoles = this._roles.Entity;
                        this._roles.Entity = null;
                        previousRoles.UsersInRoles.Remove(this);
                    }
                    this._roles.Entity = value;
                    if ((value != null))
                    {
                        value.UsersInRoles.Add(this);
                        _applicationName = value.ApplicationName;
                        _roleName = value.RoleName;
                    }
                    else
                    {
                        _applicationName = default(string);
                        _roleName = default(string);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
