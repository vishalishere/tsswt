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

        public Table<LogError> LogError
        {
            get
            {
                return this.GetTable<LogError>();
            }
        }

        public Table<MyAspNetApplications> MyAspNetApplications
        {
            get
            {
                return this.GetTable<MyAspNetApplications>();
            }
        }

        public Table<MyAspNetMembership> MyAspNetMembership
        {
            get
            {
                return this.GetTable<MyAspNetMembership>();
            }
        }

        public Table<MyAspNetProfiles> MyAspNetProfiles
        {
            get
            {
                return this.GetTable<MyAspNetProfiles>();
            }
        }

        public Table<MyAspNetRoles> MyAspNetRoles
        {
            get
            {
                return this.GetTable<MyAspNetRoles>();
            }
        }

        public Table<MyAspNetSchemaVersion> MyAspNetSchemaVersion
        {
            get
            {
                return this.GetTable<MyAspNetSchemaVersion>();
            }
        }

        public Table<MyAspNetSessionCleanup> MyAspNetSessionCleanup
        {
            get
            {
                return this.GetTable<MyAspNetSessionCleanup>();
            }
        }

        public Table<MyAspNetSessions> MyAspNetSessions
        {
            get
            {
                return this.GetTable<MyAspNetSessions>();
            }
        }

        public Table<MyAspNetUsers> MyAspNetUsers
        {
            get
            {
                return this.GetTable<MyAspNetUsers>();
            }
        }

        public Table<MyAspNetUsersInRoles> MyAspNetUsersInRoles
        {
            get
            {
                return this.GetTable<MyAspNetUsersInRoles>();
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

        public Table<ResourceAssignment> ResourceAssignment
        {
            get
            {
                return this.GetTable<ResourceAssignment>();
            }
        }

        public Table<ResourceAssignmentException> ResourceAssignmentException
        {
            get
            {
                return this.GetTable<ResourceAssignmentException>();
            }
        }

        public Table<SCP> SCP
        {
            get
            {
                return this.GetTable<SCP>();
            }
        }

        public Table<SCPProject> SCPProject
        {
            get
            {
                return this.GetTable<SCPProject>();
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

        private System.DateTime _startHour;

        private string _t;

        private string _ticket;

        private EntityRef<Period> _period = new EntityRef<Period>();

        private EntityRef<Resource> _resource = new EntityRef<Resource>();

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

    [Table(Name = "swt.logerror")]
    public partial class LogError : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _date;

        private int _idlOgError;

        private int _iduSer;

        private string _message;

        private string _stackTrace;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnIdlOgErrorChanged();

        partial void OnIdlOgErrorChanging(int value);

        partial void OnIduSerChanged();

        partial void OnIduSerChanging(int value);

        partial void OnMessageChanged();

        partial void OnMessageChanging(string value);

        partial void OnStackTraceChanged();

        partial void OnStackTraceChanging(string value);
        #endregion


        public LogError()
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

        [Column(Storage = "_idlOgError", Name = "IDLogError", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdlOgError
        {
            get
            {
                return this._idlOgError;
            }
            set
            {
                if ((_idlOgError != value))
                {
                    this.OnIdlOgErrorChanging(value);
                    this.SendPropertyChanging();
                    this._idlOgError = value;
                    this.SendPropertyChanged("IdlOgError");
                    this.OnIdlOgErrorChanged();
                }
            }
        }

        [Column(Storage = "_iduSer", Name = "IDUser", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IduSer
        {
            get
            {
                return this._iduSer;
            }
            set
            {
                if ((_iduSer != value))
                {
                    this.OnIduSerChanging(value);
                    this.SendPropertyChanging();
                    this._iduSer = value;
                    this.SendPropertyChanged("IduSer");
                    this.OnIduSerChanged();
                }
            }
        }

        [Column(Storage = "_message", Name = "Message", DbType = "varchar(4000)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                if (((_message == value)
                            == false))
                {
                    this.OnMessageChanging(value);
                    this.SendPropertyChanging();
                    this._message = value;
                    this.SendPropertyChanged("Message");
                    this.OnMessageChanged();
                }
            }
        }

        [Column(Storage = "_stackTrace", Name = "StackTrace", DbType = "varchar(4000)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string StackTrace
        {
            get
            {
                return this._stackTrace;
            }
            set
            {
                if (((_stackTrace == value)
                            == false))
                {
                    this.OnStackTraceChanging(value);
                    this.SendPropertyChanging();
                    this._stackTrace = value;
                    this.SendPropertyChanged("StackTrace");
                    this.OnStackTraceChanged();
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

    [Table(Name = "swt.my_aspnet_applications")]
    public partial class MyAspNetApplications : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _description;

        private int _id;

        private string _name;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);
        #endregion


        public MyAspNetApplications()
        {
            this.OnCreated();
        }

        [Column(Storage = "_description", Name = "description", DbType = "varchar(256)", AutoSync = AutoSync.Never)]
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

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(256)", AutoSync = AutoSync.Never)]
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

    [Table(Name = "swt.my_aspnet_membership")]
    public partial class MyAspNetMembership : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _comment;

        private System.Nullable<System.DateTime> _creationDate;

        private string _email;

        private System.Nullable<uint> _failedPasswordAnswerAttemptCount;

        private System.Nullable<System.DateTime> _failedPasswordAnswerAttemptWindowStart;

        private System.Nullable<uint> _failedPasswordAttemptCount;

        private System.Nullable<System.DateTime> _failedPasswordAttemptWindowStart;

        private System.Nullable<sbyte> _isApproved;

        private System.Nullable<sbyte> _isLockedOut;

        private System.Nullable<System.DateTime> _lastActivityDate;

        private System.Nullable<System.DateTime> _lastLockedOutDate;

        private System.Nullable<System.DateTime> _lastLoginDate;

        private System.Nullable<System.DateTime> _lastPasswordChangedDate;

        private string _password;

        private string _passwordAnswer;

        private System.Nullable<sbyte> _passwordFormat;

        private string _passwordKey;

        private string _passwordQuestion;

        private int _userID;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCommentChanged();

        partial void OnCommentChanging(string value);

        partial void OnCreationDateChanged();

        partial void OnCreationDateChanging(System.Nullable<System.DateTime> value);

        partial void OnEmailChanged();

        partial void OnEmailChanging(string value);

        partial void OnFailedPasswordAnswerAttemptCountChanged();

        partial void OnFailedPasswordAnswerAttemptCountChanging(System.Nullable<uint> value);

        partial void OnFailedPasswordAnswerAttemptWindowStartChanged();

        partial void OnFailedPasswordAnswerAttemptWindowStartChanging(System.Nullable<System.DateTime> value);

        partial void OnFailedPasswordAttemptCountChanged();

        partial void OnFailedPasswordAttemptCountChanging(System.Nullable<uint> value);

        partial void OnFailedPasswordAttemptWindowStartChanged();

        partial void OnFailedPasswordAttemptWindowStartChanging(System.Nullable<System.DateTime> value);

        partial void OnIsApprovedChanged();

        partial void OnIsApprovedChanging(System.Nullable<sbyte> value);

        partial void OnIsLockedOutChanged();

        partial void OnIsLockedOutChanging(System.Nullable<sbyte> value);

        partial void OnLastActivityDateChanged();

        partial void OnLastActivityDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastLockedOutDateChanged();

        partial void OnLastLockedOutDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastLoginDateChanged();

        partial void OnLastLoginDateChanging(System.Nullable<System.DateTime> value);

        partial void OnLastPasswordChangedDateChanged();

        partial void OnLastPasswordChangedDateChanging(System.Nullable<System.DateTime> value);

        partial void OnPasswordChanged();

        partial void OnPasswordChanging(string value);

        partial void OnPasswordAnswerChanged();

        partial void OnPasswordAnswerChanging(string value);

        partial void OnPasswordFormatChanged();

        partial void OnPasswordFormatChanging(System.Nullable<sbyte> value);

        partial void OnPasswordKeyChanged();

        partial void OnPasswordKeyChanging(string value);

        partial void OnPasswordQuestionChanged();

        partial void OnPasswordQuestionChanging(string value);

        partial void OnUserIDChanged();

        partial void OnUserIDChanging(int value);
        #endregion


        public MyAspNetMembership()
        {
            this.OnCreated();
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

        [Column(Storage = "_email", Name = "Email", DbType = "varchar(128)", AutoSync = AutoSync.Never)]
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

        [Column(Storage = "_failedPasswordAnswerAttemptCount", Name = "FailedPasswordAnswerAttemptCount", DbType = "int unsigned", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<uint> FailedPasswordAnswerAttemptCount
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

        [Column(Storage = "_failedPasswordAttemptCount", Name = "FailedPasswordAttemptCount", DbType = "int unsigned", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<uint> FailedPasswordAttemptCount
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

        [Column(Storage = "_lastPasswordChangedDate", Name = "LastPasswordChangedDate", DbType = "datetime", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<System.DateTime> LastPasswordChangedDate
        {
            get
            {
                return this._lastPasswordChangedDate;
            }
            set
            {
                if ((_lastPasswordChangedDate != value))
                {
                    this.OnLastPasswordChangedDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastPasswordChangedDate = value;
                    this.SendPropertyChanged("LastPasswordChangedDate");
                    this.OnLastPasswordChangedDateChanged();
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

        [Column(Storage = "_passwordFormat", Name = "PasswordFormat", DbType = "tinyint(4)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<sbyte> PasswordFormat
        {
            get
            {
                return this._passwordFormat;
            }
            set
            {
                if ((_passwordFormat != value))
                {
                    this.OnPasswordFormatChanging(value);
                    this.SendPropertyChanging();
                    this._passwordFormat = value;
                    this.SendPropertyChanged("PasswordFormat");
                    this.OnPasswordFormatChanged();
                }
            }
        }

        [Column(Storage = "_passwordKey", Name = "PasswordKey", DbType = "char(32)", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string PasswordKey
        {
            get
            {
                return this._passwordKey;
            }
            set
            {
                if (((_passwordKey == value)
                            == false))
                {
                    this.OnPasswordKeyChanging(value);
                    this.SendPropertyChanging();
                    this._passwordKey = value;
                    this.SendPropertyChanged("PasswordKey");
                    this.OnPasswordKeyChanged();
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

        [Column(Storage = "_userID", Name = "userId", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if ((_userID != value))
                {
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._userID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
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

    [Table(Name = "swt.my_aspnet_profiles")]
    public partial class MyAspNetProfiles : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private byte[] _binaryData;

        private System.DateTime _lastUpdatedDate;

        private string _stringData;

        private int _userID;

        private string _valueIndex;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnBinaryDataChanged();

        partial void OnBinaryDataChanging(byte[] value);

        partial void OnLastUpdatedDateChanged();

        partial void OnLastUpdatedDateChanging(System.DateTime value);

        partial void OnStringDataChanged();

        partial void OnStringDataChanging(string value);

        partial void OnUserIDChanged();

        partial void OnUserIDChanging(int value);

        partial void OnValueIndexChanged();

        partial void OnValueIndexChanging(string value);
        #endregion


        public MyAspNetProfiles()
        {
            this.OnCreated();
        }

        [Column(Storage = "_binaryData", Name = "binarydata", DbType = "longblob", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public byte[] BinaryData
        {
            get
            {
                return this._binaryData;
            }
            set
            {
                if (((_binaryData == value)
                            == false))
                {
                    this.OnBinaryDataChanging(value);
                    this.SendPropertyChanging();
                    this._binaryData = value;
                    this.SendPropertyChanged("BinaryData");
                    this.OnBinaryDataChanged();
                }
            }
        }

        [Column(Storage = "_lastUpdatedDate", Name = "lastUpdatedDate", DbType = "timestamp", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime LastUpdatedDate
        {
            get
            {
                return this._lastUpdatedDate;
            }
            set
            {
                if ((_lastUpdatedDate != value))
                {
                    this.OnLastUpdatedDateChanging(value);
                    this.SendPropertyChanging();
                    this._lastUpdatedDate = value;
                    this.SendPropertyChanged("LastUpdatedDate");
                    this.OnLastUpdatedDateChanged();
                }
            }
        }

        [Column(Storage = "_stringData", Name = "stringdata", DbType = "longtext", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string StringData
        {
            get
            {
                return this._stringData;
            }
            set
            {
                if (((_stringData == value)
                            == false))
                {
                    this.OnStringDataChanging(value);
                    this.SendPropertyChanging();
                    this._stringData = value;
                    this.SendPropertyChanged("StringData");
                    this.OnStringDataChanged();
                }
            }
        }

        [Column(Storage = "_userID", Name = "userId", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if ((_userID != value))
                {
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._userID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
                }
            }
        }

        [Column(Storage = "_valueIndex", Name = "valueindex", DbType = "longtext", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public string ValueIndex
        {
            get
            {
                return this._valueIndex;
            }
            set
            {
                if (((_valueIndex == value)
                            == false))
                {
                    this.OnValueIndexChanging(value);
                    this.SendPropertyChanging();
                    this._valueIndex = value;
                    this.SendPropertyChanged("ValueIndex");
                    this.OnValueIndexChanged();
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

    [Table(Name = "swt.my_aspnet_roles")]
    public partial class MyAspNetRoles : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _applicationID;

        private int _id;

        private string _name;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationIDChanged();

        partial void OnApplicationIDChanging(int value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);
        #endregion


        public MyAspNetRoles()
        {
            this.OnCreated();
        }

        [Column(Storage = "_applicationID", Name = "applicationId", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ApplicationID
        {
            get
            {
                return this._applicationID;
            }
            set
            {
                if ((_applicationID != value))
                {
                    this.OnApplicationIDChanging(value);
                    this.SendPropertyChanging();
                    this._applicationID = value;
                    this.SendPropertyChanged("ApplicationID");
                    this.OnApplicationIDChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_name", Name = "name", DbType = "varchar(255)", AutoSync = AutoSync.Never, CanBeNull = false)]
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

    [Table(Name = "swt.my_aspnet_schemaversion")]
    public partial class MyAspNetSchemaVersion
    {

        private System.Nullable<int> _version;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnVersionChanged();

        partial void OnVersionChanging(System.Nullable<int> value);
        #endregion


        public MyAspNetSchemaVersion()
        {
            this.OnCreated();
        }

        [Column(Storage = "_version", Name = "version", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> Version
        {
            get
            {
                return this._version;
            }
            set
            {
                if ((_version != value))
                {
                    this.OnVersionChanging(value);
                    this._version = value;
                    this.OnVersionChanged();
                }
            }
        }
    }

    [Table(Name = "swt.my_aspnet_sessioncleanup")]
    public partial class MyAspNetSessionCleanup
    {

        private int _intervalMinutes;

        private System.DateTime _lastRun;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnIntervalMinutesChanged();

        partial void OnIntervalMinutesChanging(int value);

        partial void OnLastRunChanged();

        partial void OnLastRunChanging(System.DateTime value);
        #endregion


        public MyAspNetSessionCleanup()
        {
            this.OnCreated();
        }

        [Column(Storage = "_intervalMinutes", Name = "IntervalMinutes", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IntervalMinutes
        {
            get
            {
                return this._intervalMinutes;
            }
            set
            {
                if ((_intervalMinutes != value))
                {
                    this.OnIntervalMinutesChanging(value);
                    this._intervalMinutes = value;
                    this.OnIntervalMinutesChanged();
                }
            }
        }

        [Column(Storage = "_lastRun", Name = "LastRun", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime LastRun
        {
            get
            {
                return this._lastRun;
            }
            set
            {
                if ((_lastRun != value))
                {
                    this.OnLastRunChanging(value);
                    this._lastRun = value;
                    this.OnLastRunChanged();
                }
            }
        }
    }

    [Table(Name = "swt.my_aspnet_sessions")]
    public partial class MyAspNetSessions : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _applicationID;

        private System.DateTime _created;

        private System.DateTime _expires;

        private int _flags;

        private System.DateTime _lockDate;

        private sbyte _locked;

        private int _lockID;

        private string _sessionID;

        private byte[] _sessionItems;

        private int _timeout;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationIDChanged();

        partial void OnApplicationIDChanging(int value);

        partial void OnCreatedChanged();

        partial void OnCreatedChanging(System.DateTime value);

        partial void OnExpiresChanged();

        partial void OnExpiresChanging(System.DateTime value);

        partial void OnFlagsChanged();

        partial void OnFlagsChanging(int value);

        partial void OnLockDateChanged();

        partial void OnLockDateChanging(System.DateTime value);

        partial void OnLockedChanged();

        partial void OnLockedChanging(sbyte value);

        partial void OnLockIDChanged();

        partial void OnLockIDChanging(int value);

        partial void OnSessionIDChanged();

        partial void OnSessionIDChanging(string value);

        partial void OnSessionItemsChanged();

        partial void OnSessionItemsChanging(byte[] value);

        partial void OnTimeoutChanged();

        partial void OnTimeoutChanging(int value);
        #endregion


        public MyAspNetSessions()
        {
            this.OnCreated();
        }

        [Column(Storage = "_applicationID", Name = "ApplicationId", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ApplicationID
        {
            get
            {
                return this._applicationID;
            }
            set
            {
                if ((_applicationID != value))
                {
                    this.OnApplicationIDChanging(value);
                    this.SendPropertyChanging();
                    this._applicationID = value;
                    this.SendPropertyChanged("ApplicationID");
                    this.OnApplicationIDChanged();
                }
            }
        }

        [Column(Storage = "_created", Name = "Created", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Created
        {
            get
            {
                return this._created;
            }
            set
            {
                if ((_created != value))
                {
                    this.OnCreatedChanging(value);
                    this.SendPropertyChanging();
                    this._created = value;
                    this.SendPropertyChanged("Created");
                    this.OnCreatedChanged();
                }
            }
        }

        [Column(Storage = "_expires", Name = "Expires", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime Expires
        {
            get
            {
                return this._expires;
            }
            set
            {
                if ((_expires != value))
                {
                    this.OnExpiresChanging(value);
                    this.SendPropertyChanging();
                    this._expires = value;
                    this.SendPropertyChanged("Expires");
                    this.OnExpiresChanged();
                }
            }
        }

        [Column(Storage = "_flags", Name = "Flags", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Flags
        {
            get
            {
                return this._flags;
            }
            set
            {
                if ((_flags != value))
                {
                    this.OnFlagsChanging(value);
                    this.SendPropertyChanging();
                    this._flags = value;
                    this.SendPropertyChanged("Flags");
                    this.OnFlagsChanged();
                }
            }
        }

        [Column(Storage = "_lockDate", Name = "LockDate", DbType = "datetime", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public System.DateTime LockDate
        {
            get
            {
                return this._lockDate;
            }
            set
            {
                if ((_lockDate != value))
                {
                    this.OnLockDateChanging(value);
                    this.SendPropertyChanging();
                    this._lockDate = value;
                    this.SendPropertyChanged("LockDate");
                    this.OnLockDateChanged();
                }
            }
        }

        [Column(Storage = "_locked", Name = "Locked", DbType = "tinyint(1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public sbyte Locked
        {
            get
            {
                return this._locked;
            }
            set
            {
                if ((_locked != value))
                {
                    this.OnLockedChanging(value);
                    this.SendPropertyChanging();
                    this._locked = value;
                    this.SendPropertyChanged("Locked");
                    this.OnLockedChanged();
                }
            }
        }

        [Column(Storage = "_lockID", Name = "LockId", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int LockID
        {
            get
            {
                return this._lockID;
            }
            set
            {
                if ((_lockID != value))
                {
                    this.OnLockIDChanging(value);
                    this.SendPropertyChanging();
                    this._lockID = value;
                    this.SendPropertyChanged("LockID");
                    this.OnLockIDChanged();
                }
            }
        }

        [Column(Storage = "_sessionID", Name = "SessionId", DbType = "varchar(255)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string SessionID
        {
            get
            {
                return this._sessionID;
            }
            set
            {
                if (((_sessionID == value)
                            == false))
                {
                    this.OnSessionIDChanging(value);
                    this.SendPropertyChanging();
                    this._sessionID = value;
                    this.SendPropertyChanged("SessionID");
                    this.OnSessionIDChanged();
                }
            }
        }

        [Column(Storage = "_sessionItems", Name = "SessionItems", DbType = "longblob", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public byte[] SessionItems
        {
            get
            {
                return this._sessionItems;
            }
            set
            {
                if (((_sessionItems == value)
                            == false))
                {
                    this.OnSessionItemsChanging(value);
                    this.SendPropertyChanging();
                    this._sessionItems = value;
                    this.SendPropertyChanged("SessionItems");
                    this.OnSessionItemsChanged();
                }
            }
        }

        [Column(Storage = "_timeout", Name = "Timeout", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int Timeout
        {
            get
            {
                return this._timeout;
            }
            set
            {
                if ((_timeout != value))
                {
                    this.OnTimeoutChanging(value);
                    this.SendPropertyChanging();
                    this._timeout = value;
                    this.SendPropertyChanged("Timeout");
                    this.OnTimeoutChanged();
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

    [Table(Name = "swt.my_aspnet_users")]
    public partial class MyAspNetUsers : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _applicationID;

        private int _id;

        private sbyte _isAnonymous;

        private System.Nullable<System.DateTime> _lastActivityDate;

        private string _name;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnApplicationIDChanged();

        partial void OnApplicationIDChanging(int value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnIsAnonymousChanged();

        partial void OnIsAnonymousChanging(sbyte value);

        partial void OnLastActivityDateChanged();

        partial void OnLastActivityDateChanging(System.Nullable<System.DateTime> value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);
        #endregion


        public MyAspNetUsers()
        {
            this.OnCreated();
        }

        [Column(Storage = "_applicationID", Name = "applicationId", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ApplicationID
        {
            get
            {
                return this._applicationID;
            }
            set
            {
                if ((_applicationID != value))
                {
                    this.OnApplicationIDChanging(value);
                    this.SendPropertyChanging();
                    this._applicationID = value;
                    this.SendPropertyChanged("ApplicationID");
                    this.OnApplicationIDChanged();
                }
            }
        }

        [Column(Storage = "_id", Name = "id", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_isAnonymous", Name = "isAnonymous", DbType = "tinyint(1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public sbyte IsAnonymous
        {
            get
            {
                return this._isAnonymous;
            }
            set
            {
                if ((_isAnonymous != value))
                {
                    this.OnIsAnonymousChanging(value);
                    this.SendPropertyChanging();
                    this._isAnonymous = value;
                    this.SendPropertyChanged("IsAnonymous");
                    this.OnIsAnonymousChanged();
                }
            }
        }

        [Column(Storage = "_lastActivityDate", Name = "lastActivityDate", DbType = "datetime", AutoSync = AutoSync.Never)]
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

        [Column(Storage = "_name", Name = "name", DbType = "varchar(256)", AutoSync = AutoSync.Never, CanBeNull = false)]
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

    [Table(Name = "swt.my_aspnet_usersinroles")]
    public partial class MyAspNetUsersInRoles : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _roleID;

        private int _userID;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnRoleIDChanged();

        partial void OnRoleIDChanging(int value);

        partial void OnUserIDChanged();

        partial void OnUserIDChanging(int value);
        #endregion


        public MyAspNetUsersInRoles()
        {
            this.OnCreated();
        }

        [Column(Storage = "_roleID", Name = "roleId", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int RoleID
        {
            get
            {
                return this._roleID;
            }
            set
            {
                if ((_roleID != value))
                {
                    this.OnRoleIDChanging(value);
                    this.SendPropertyChanging();
                    this._roleID = value;
                    this.SendPropertyChanged("RoleID");
                    this.OnRoleIDChanged();
                }
            }
        }

        [Column(Storage = "_userID", Name = "userId", DbType = "int", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if ((_userID != value))
                {
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._userID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
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

        private EntitySet<ResourceAssignment> _resourceAssignment;

        private EntitySet<SCP> _scp;

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
            _resourceAssignment = new EntitySet<ResourceAssignment>(new Action<ResourceAssignment>(this.ResourceAssignment_Attach), new Action<ResourceAssignment>(this.ResourceAssignment_Detach));
            _scp = new EntitySet<SCP>(new Action<SCP>(this.SCP_Attach), new Action<SCP>(this.SCP_Detach));
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

        [Association(Storage = "_resourceAssignment", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_ResourceAssignment_Period")]
        [DebuggerNonUserCode()]
        public EntitySet<ResourceAssignment> ResourceAssignment
        {
            get
            {
                return this._resourceAssignment;
            }
            set
            {
                this._resourceAssignment = value;
            }
        }

        [Association(Storage = "_scp", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_SCP_Period1")]
        [DebuggerNonUserCode()]
        public EntitySet<SCP> SCP
        {
            get
            {
                return this._scp;
            }
            set
            {
                this._scp = value;
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

        private void ResourceAssignment_Attach(ResourceAssignment entity)
        {
            this.SendPropertyChanging();
            entity.Period = this;
        }

        private void ResourceAssignment_Detach(ResourceAssignment entity)
        {
            this.SendPropertyChanging();
            entity.Period = null;
        }

        private void SCP_Attach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.Period = this;
        }

        private void SCP_Detach(SCP entity)
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

        private EntitySet<ResourceAssignment> _resourceAssignment;

        private EntitySet<SCP> _scp;

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
            _resourceAssignment = new EntitySet<ResourceAssignment>(new Action<ResourceAssignment>(this.ResourceAssignment_Attach), new Action<ResourceAssignment>(this.ResourceAssignment_Detach));
            _scp = new EntitySet<SCP>(new Action<SCP>(this.SCP_Attach), new Action<SCP>(this.SCP_Detach));
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

        [Association(Storage = "_resourceAssignment", OtherKey = "T", ThisKey = "T", Name = "fk_ResourceAssignment_Resource")]
        [DebuggerNonUserCode()]
        public EntitySet<ResourceAssignment> ResourceAssignment
        {
            get
            {
                return this._resourceAssignment;
            }
            set
            {
                this._resourceAssignment = value;
            }
        }

        [Association(Storage = "_scp", OtherKey = "T", ThisKey = "T", Name = "fk_SCP_Resource1")]
        [DebuggerNonUserCode()]
        public EntitySet<SCP> SCP
        {
            get
            {
                return this._scp;
            }
            set
            {
                this._scp = value;
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

        private void ResourceAssignment_Attach(ResourceAssignment entity)
        {
            this.SendPropertyChanging();
            entity.Resource = this;
        }

        private void ResourceAssignment_Detach(ResourceAssignment entity)
        {
            this.SendPropertyChanging();
            entity.Resource = null;
        }

        private void SCP_Attach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.Resource = this;
        }

        private void SCP_Detach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.Resource = null;
        }
        #endregion
    }

    [Table(Name = "swt.resourceassignment")]
    public partial class ResourceAssignment : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private decimal _hoursPerDay;

        private int _idpEriod;

        private int _idrEsourceAssignment;

        private string _t;

        private EntitySet<ResourceAssignmentException> _resourceAssignmentException;

        private EntityRef<Period> _period = new EntityRef<Period>();

        private EntityRef<Resource> _resource = new EntityRef<Resource>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnHoursPerDayChanged();

        partial void OnHoursPerDayChanging(decimal value);

        partial void OnIdpEriodChanged();

        partial void OnIdpEriodChanging(int value);

        partial void OnIdrEsourceAssignmentChanged();

        partial void OnIdrEsourceAssignmentChanging(int value);

        partial void OnTChanged();

        partial void OnTChanging(string value);
        #endregion


        public ResourceAssignment()
        {
            _resourceAssignmentException = new EntitySet<ResourceAssignmentException>(new Action<ResourceAssignmentException>(this.ResourceAssignmentException_Attach), new Action<ResourceAssignmentException>(this.ResourceAssignmentException_Detach));
            this.OnCreated();
        }

        [Column(Storage = "_hoursPerDay", Name = "HoursPerDay", DbType = "decimal(4,1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public decimal HoursPerDay
        {
            get
            {
                return this._hoursPerDay;
            }
            set
            {
                if ((_hoursPerDay != value))
                {
                    this.OnHoursPerDayChanging(value);
                    this.SendPropertyChanging();
                    this._hoursPerDay = value;
                    this.SendPropertyChanged("HoursPerDay");
                    this.OnHoursPerDayChanged();
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

        [Column(Storage = "_idrEsourceAssignment", Name = "IDResourceAssignment", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdrEsourceAssignment
        {
            get
            {
                return this._idrEsourceAssignment;
            }
            set
            {
                if ((_idrEsourceAssignment != value))
                {
                    this.OnIdrEsourceAssignmentChanging(value);
                    this.SendPropertyChanging();
                    this._idrEsourceAssignment = value;
                    this.SendPropertyChanged("IdrEsourceAssignment");
                    this.OnIdrEsourceAssignmentChanged();
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
                    if (_resource.HasLoadedOrAssignedValue)
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

        #region Children
        [Association(Storage = "_resourceAssignmentException", OtherKey = "IdrEsourceAssignment", ThisKey = "IdrEsourceAssignment", Name = "fk_ResourceAssignmentException_ResourceAssignment1")]
        [DebuggerNonUserCode()]
        public EntitySet<ResourceAssignmentException> ResourceAssignmentException
        {
            get
            {
                return this._resourceAssignmentException;
            }
            set
            {
                this._resourceAssignmentException = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage = "_period", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_ResourceAssignment_Period", IsForeignKey = true)]
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
                        previousPeriod.ResourceAssignment.Remove(this);
                    }
                    this._period.Entity = value;
                    if ((value != null))
                    {
                        value.ResourceAssignment.Add(this);
                        _idpEriod = value.IdpEriod;
                    }
                    else
                    {
                        _idpEriod = default(int);
                    }
                }
            }
        }

        [Association(Storage = "_resource", OtherKey = "T", ThisKey = "T", Name = "fk_ResourceAssignment_Resource", IsForeignKey = true)]
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
                        previousResource.ResourceAssignment.Remove(this);
                    }
                    this._resource.Entity = value;
                    if ((value != null))
                    {
                        value.ResourceAssignment.Add(this);
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

        #region Attachment handlers
        private void ResourceAssignmentException_Attach(ResourceAssignmentException entity)
        {
            this.SendPropertyChanging();
            entity.ResourceAssignment = this;
        }

        private void ResourceAssignmentException_Detach(ResourceAssignmentException entity)
        {
            this.SendPropertyChanging();
            entity.ResourceAssignment = null;
        }
        #endregion
    }

    [Table(Name = "swt.resourceassignmentexception")]
    public partial class ResourceAssignmentException : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _date;

        private decimal _hoursInDay;

        private int _idrEsourceAssignment;

        private int _idrEsourceAssignmentException;

        private string _reason;

        private EntityRef<ResourceAssignment> _resourceAssignment = new EntityRef<ResourceAssignment>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnHoursInDayChanged();

        partial void OnHoursInDayChanging(decimal value);

        partial void OnIdrEsourceAssignmentChanged();

        partial void OnIdrEsourceAssignmentChanging(int value);

        partial void OnIdrEsourceAssignmentExceptionChanged();

        partial void OnIdrEsourceAssignmentExceptionChanging(int value);

        partial void OnReasonChanged();

        partial void OnReasonChanging(string value);
        #endregion


        public ResourceAssignmentException()
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

        [Column(Storage = "_hoursInDay", Name = "HoursInDay", DbType = "decimal(4,1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public decimal HoursInDay
        {
            get
            {
                return this._hoursInDay;
            }
            set
            {
                if ((_hoursInDay != value))
                {
                    this.OnHoursInDayChanging(value);
                    this.SendPropertyChanging();
                    this._hoursInDay = value;
                    this.SendPropertyChanged("HoursInDay");
                    this.OnHoursInDayChanged();
                }
            }
        }

        [Column(Storage = "_idrEsourceAssignment", Name = "IDResourceAssignment", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdrEsourceAssignment
        {
            get
            {
                return this._idrEsourceAssignment;
            }
            set
            {
                if ((_idrEsourceAssignment != value))
                {
                    this.OnIdrEsourceAssignmentChanging(value);
                    this.SendPropertyChanging();
                    this._idrEsourceAssignment = value;
                    this.SendPropertyChanged("IdrEsourceAssignment");
                    this.OnIdrEsourceAssignmentChanged();
                }
            }
        }

        [Column(Storage = "_idrEsourceAssignmentException", Name = "IDResourceAssignmentException", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IdrEsourceAssignmentException
        {
            get
            {
                return this._idrEsourceAssignmentException;
            }
            set
            {
                if ((_idrEsourceAssignmentException != value))
                {
                    this.OnIdrEsourceAssignmentExceptionChanging(value);
                    this.SendPropertyChanging();
                    this._idrEsourceAssignmentException = value;
                    this.SendPropertyChanged("IdrEsourceAssignmentException");
                    this.OnIdrEsourceAssignmentExceptionChanged();
                }
            }
        }

        [Column(Storage = "_reason", Name = "Reason", DbType = "varchar(500)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string Reason
        {
            get
            {
                return this._reason;
            }
            set
            {
                if (((_reason == value)
                            == false))
                {
                    this.OnReasonChanging(value);
                    this.SendPropertyChanging();
                    this._reason = value;
                    this.SendPropertyChanged("Reason");
                    this.OnReasonChanged();
                }
            }
        }

        #region Parents
        [Association(Storage = "_resourceAssignment", OtherKey = "IdrEsourceAssignment", ThisKey = "IdrEsourceAssignment", Name = "fk_ResourceAssignmentException_ResourceAssignment1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public ResourceAssignment ResourceAssignment
        {
            get
            {
                return this._resourceAssignment.Entity;
            }
            set
            {
                if (((this._resourceAssignment.Entity == value)
                            == false))
                {
                    if ((this._resourceAssignment.Entity != null))
                    {
                        ResourceAssignment previousResourceAssignment = this._resourceAssignment.Entity;
                        this._resourceAssignment.Entity = null;
                        previousResourceAssignment.ResourceAssignmentException.Remove(this);
                    }
                    this._resourceAssignment.Entity = value;
                    if ((value != null))
                    {
                        value.ResourceAssignmentException.Add(this);
                        _idrEsourceAssignment = value.IdrEsourceAssignment;
                    }
                    else
                    {
                        _idrEsourceAssignment = default(int);
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

    [Table(Name = "swt.scp")]
    public partial class SCP : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _date;

        private decimal _hours;

        private int _idpEriod;

        private int _idsCp;

        private string _idsCppRoject;

        private string _number;

        private string _t;

        private EntityRef<Period> _period = new EntityRef<Period>();

        private EntityRef<Resource> _resource = new EntityRef<Resource>();

        private EntityRef<SCPProject> _scppRoject = new EntityRef<SCPProject>();

        private EntityRef<Ticket> _ticket = new EntityRef<Ticket>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnHoursChanged();

        partial void OnHoursChanging(decimal value);

        partial void OnIdpEriodChanged();

        partial void OnIdpEriodChanging(int value);

        partial void OnIDScpChanged();

        partial void OnIDScpChanging(int value);

        partial void OnIDScppRojectChanged();

        partial void OnIDScppRojectChanging(string value);

        partial void OnNumberChanged();

        partial void OnNumberChanging(string value);

        partial void OnTChanged();

        partial void OnTChanging(string value);
        #endregion


        public SCP()
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

        [Column(Storage = "_hours", Name = "Hours", DbType = "decimal(4,1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public decimal Hours
        {
            get
            {
                return this._hours;
            }
            set
            {
                if ((_hours != value))
                {
                    this.OnHoursChanging(value);
                    this.SendPropertyChanging();
                    this._hours = value;
                    this.SendPropertyChanged("Hours");
                    this.OnHoursChanged();
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

        [Column(Storage = "_idsCp", Name = "idSCP", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDScp
        {
            get
            {
                return this._idsCp;
            }
            set
            {
                if ((_idsCp != value))
                {
                    this.OnIDScpChanging(value);
                    this.SendPropertyChanging();
                    this._idsCp = value;
                    this.SendPropertyChanged("IDScp");
                    this.OnIDScpChanged();
                }
            }
        }

        [Column(Storage = "_idsCppRoject", Name = "idSCPProject", DbType = "varchar(20)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IDScppRoject
        {
            get
            {
                return this._idsCppRoject;
            }
            set
            {
                if (((_idsCppRoject == value)
                            == false))
                {
                    this.OnIDScppRojectChanging(value);
                    this.SendPropertyChanging();
                    this._idsCppRoject = value;
                    this.SendPropertyChanged("IDScppRoject");
                    this.OnIDScppRojectChanged();
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
                    if (_resource.HasLoadedOrAssignedValue)
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

        #region Parents
        [Association(Storage = "_period", OtherKey = "IdpEriod", ThisKey = "IdpEriod", Name = "fk_SCP_Period1", IsForeignKey = true)]
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
                        previousPeriod.SCP.Remove(this);
                    }
                    this._period.Entity = value;
                    if ((value != null))
                    {
                        value.SCP.Add(this);
                        _idpEriod = value.IdpEriod;
                    }
                    else
                    {
                        _idpEriod = default(int);
                    }
                }
            }
        }

        [Association(Storage = "_resource", OtherKey = "T", ThisKey = "T", Name = "fk_SCP_Resource1", IsForeignKey = true)]
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
                        previousResource.SCP.Remove(this);
                    }
                    this._resource.Entity = value;
                    if ((value != null))
                    {
                        value.SCP.Add(this);
                        _t = value.T;
                    }
                    else
                    {
                        _t = default(string);
                    }
                }
            }
        }

        [Association(Storage = "_scppRoject", OtherKey = "IDScppRoject", ThisKey = "IDScppRoject", Name = "fk_SCP_SCPProject1", IsForeignKey = true)]
        [DebuggerNonUserCode()]
        public SCPProject SCPProject
        {
            get
            {
                return this._scppRoject.Entity;
            }
            set
            {
                if (((this._scppRoject.Entity == value)
                            == false))
                {
                    if ((this._scppRoject.Entity != null))
                    {
                        SCPProject previousSCPProject = this._scppRoject.Entity;
                        this._scppRoject.Entity = null;
                        previousSCPProject.SCP.Remove(this);
                    }
                    this._scppRoject.Entity = value;
                    if ((value != null))
                    {
                        value.SCP.Add(this);
                        _idsCppRoject = value.IDScppRoject;
                    }
                    else
                    {
                        _idsCppRoject = default(string);
                    }
                }
            }
        }

        [Association(Storage = "_ticket", OtherKey = "Number", ThisKey = "Number", Name = "fk_SCP_Ticket1", IsForeignKey = true)]
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
                        previousTicket.SCP.Remove(this);
                    }
                    this._ticket.Entity = value;
                    if ((value != null))
                    {
                        value.SCP.Add(this);
                        _number = value.Number;
                    }
                    else
                    {
                        _number = default(string);
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

    [Table(Name = "swt.scpproject")]
    public partial class SCPProject : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private string _description;

        private string _idsCppRoject;

        private System.Nullable<int> _type;

        private EntitySet<SCP> _scp;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnIDScppRojectChanged();

        partial void OnIDScppRojectChanging(string value);

        partial void OnTypeChanged();

        partial void OnTypeChanging(System.Nullable<int> value);
        #endregion


        public SCPProject()
        {
            _scp = new EntitySet<SCP>(new Action<SCP>(this.SCP_Attach), new Action<SCP>(this.SCP_Detach));
            this.OnCreated();
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

        [Column(Storage = "_idsCppRoject", Name = "idSCPProject", DbType = "varchar(20)", IsPrimaryKey = true, AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public string IDScppRoject
        {
            get
            {
                return this._idsCppRoject;
            }
            set
            {
                if (((_idsCppRoject == value)
                            == false))
                {
                    this.OnIDScppRojectChanging(value);
                    this.SendPropertyChanging();
                    this._idsCppRoject = value;
                    this.SendPropertyChanged("IDScppRoject");
                    this.OnIDScppRojectChanged();
                }
            }
        }

        [Column(Storage = "_type", Name = "Type", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> Type
        {
            get
            {
                return this._type;
            }
            set
            {
                if ((_type != value))
                {
                    this.OnTypeChanging(value);
                    this.SendPropertyChanging();
                    this._type = value;
                    this.SendPropertyChanged("Type");
                    this.OnTypeChanged();
                }
            }
        }

        #region Children
        [Association(Storage = "_scp", OtherKey = "IDScppRoject", ThisKey = "IDScppRoject", Name = "fk_SCP_SCPProject1")]
        [DebuggerNonUserCode()]
        public EntitySet<SCP> SCP
        {
            get
            {
                return this._scp;
            }
            set
            {
                this._scp = value;
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
        private void SCP_Attach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.SCPProject = this;
        }

        private void SCP_Detach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.SCPProject = null;
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

        [Column(Storage = "_description", Name = "Description", DbType = "varchar(400)", AutoSync = AutoSync.Never, CanBeNull = false)]
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

        [Column(Storage = "_estimatedHours", Name = "EstimatedHours", DbType = "decimal(4,1)", AutoSync = AutoSync.Never)]
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

        private int _category;

        private decimal _consumedHours;

        private System.DateTime _dateCreate;

        private System.Nullable<System.DateTime> _dateDelete;

        private System.DateTime _dateLastModified;

        private System.Nullable<System.DateTime> _deliveryDate;

        private string _description;

        private int _idcLuster;

        private int _iduSerCreate;

        private System.Nullable<int> _iduSerDelete;

        private int _iduSerLastModified;

        private sbyte _isCertifiable;

        private sbyte _isRework;

        private string _number;

        private int _priority;

        private System.Nullable<System.DateTime> _realDeliveryDate;

        private System.Nullable<System.DateTime> _startDate;

        private int _status;

        private string _system;

        private string _title;

        private EntitySet<SCP> _scp;

        private EntitySet<Task> _task;

        private EntitySet<TicketComment> _ticketComment;

        private EntityRef<Cluster> _cluster = new EntityRef<Cluster>();

        #region Extensibility Method Declarations
        partial void OnCreated();

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

        partial void OnIDUserCreateChanged();

        partial void OnIDUserCreateChanging(int value);

        partial void OnIDUserDeleteChanged();

        partial void OnIDUserDeleteChanging(System.Nullable<int> value);

        partial void OnIDUserLastModifiedChanged();

        partial void OnIDUserLastModifiedChanging(int value);

        partial void OnIsCertifiableChanged();

        partial void OnIsCertifiableChanging(sbyte value);

        partial void OnIsReworkChanged();

        partial void OnIsReworkChanging(sbyte value);

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
            _scp = new EntitySet<SCP>(new Action<SCP>(this.SCP_Attach), new Action<SCP>(this.SCP_Detach));
            _task = new EntitySet<Task>(new Action<Task>(this.Task_Attach), new Action<Task>(this.Task_Detach));
            _ticketComment = new EntitySet<TicketComment>(new Action<TicketComment>(this.TicketComment_Attach), new Action<TicketComment>(this.TicketComment_Detach));
            this.OnCreated();
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

        [Column(Storage = "_iduSerCreate", Name = "IdUserCreate", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDUserCreate
        {
            get
            {
                return this._iduSerCreate;
            }
            set
            {
                if ((_iduSerCreate != value))
                {
                    this.OnIDUserCreateChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerCreate = value;
                    this.SendPropertyChanged("IDUserCreate");
                    this.OnIDUserCreateChanged();
                }
            }
        }

        [Column(Storage = "_iduSerDelete", Name = "IdUserDelete", DbType = "int", AutoSync = AutoSync.Never)]
        [DebuggerNonUserCode()]
        public System.Nullable<int> IDUserDelete
        {
            get
            {
                return this._iduSerDelete;
            }
            set
            {
                if ((_iduSerDelete != value))
                {
                    this.OnIDUserDeleteChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerDelete = value;
                    this.SendPropertyChanged("IDUserDelete");
                    this.OnIDUserDeleteChanged();
                }
            }
        }

        [Column(Storage = "_iduSerLastModified", Name = "IdUserLastModified", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDUserLastModified
        {
            get
            {
                return this._iduSerLastModified;
            }
            set
            {
                if ((_iduSerLastModified != value))
                {
                    this.OnIDUserLastModifiedChanging(value);
                    this.SendPropertyChanging();
                    this._iduSerLastModified = value;
                    this.SendPropertyChanged("IDUserLastModified");
                    this.OnIDUserLastModifiedChanged();
                }
            }
        }

        [Column(Storage = "_isCertifiable", Name = "IsCertifiable", DbType = "tinyint(1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public sbyte IsCertifiable
        {
            get
            {
                return this._isCertifiable;
            }
            set
            {
                if ((_isCertifiable != value))
                {
                    this.OnIsCertifiableChanging(value);
                    this.SendPropertyChanging();
                    this._isCertifiable = value;
                    this.SendPropertyChanged("IsCertifiable");
                    this.OnIsCertifiableChanged();
                }
            }
        }

        [Column(Storage = "_isRework", Name = "IsRework", DbType = "tinyint(1)", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public sbyte IsRework
        {
            get
            {
                return this._isRework;
            }
            set
            {
                if ((_isRework != value))
                {
                    this.OnIsReworkChanging(value);
                    this.SendPropertyChanging();
                    this._isRework = value;
                    this.SendPropertyChanged("IsRework");
                    this.OnIsReworkChanged();
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
        [Association(Storage = "_scp", OtherKey = "Number", ThisKey = "Number", Name = "fk_SCP_Ticket1")]
        [DebuggerNonUserCode()]
        public EntitySet<SCP> SCP
        {
            get
            {
                return this._scp;
            }
            set
            {
                this._scp = value;
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
        private void SCP_Attach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = this;
        }

        private void SCP_Detach(SCP entity)
        {
            this.SendPropertyChanging();
            entity.Ticket = null;
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

        private int _iduSer;

        private string _number;

        private EntityRef<Ticket> _ticket = new EntityRef<Ticket>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnCommentChanged();

        partial void OnCommentChanging(string value);

        partial void OnDateChanged();

        partial void OnDateChanging(System.DateTime value);

        partial void OnIdtIcketCommentChanged();

        partial void OnIdtIcketCommentChanging(int value);

        partial void OnIDUserChanged();

        partial void OnIDUserChanging(int value);

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

        [Column(Storage = "_iduSer", Name = "IdUser", DbType = "int", AutoSync = AutoSync.Never, CanBeNull = false)]
        [DebuggerNonUserCode()]
        public int IDUser
        {
            get
            {
                return this._iduSer;
            }
            set
            {
                if ((_iduSer != value))
                {
                    this.OnIDUserChanging(value);
                    this.SendPropertyChanging();
                    this._iduSer = value;
                    this.SendPropertyChanged("IDUser");
                    this.OnIDUserChanged();
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
