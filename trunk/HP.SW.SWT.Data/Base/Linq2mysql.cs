// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from swt on 2012-05-06 00:30:47Z.
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

        private static string MySqlConnection(string connectionString)
        {
            throw new NotImplementedException();
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

        internal Table<Cluster> Cluster
		{
			get
			{
				return this.GetTable<Cluster>();
			}
		}

        internal Table<ExcelRow> ExcelRow
		{
			get
			{
				return this.GetTable<ExcelRow>();
			}
		}

        internal Table<Holiday> Holiday
		{
			get
			{
				return this.GetTable<Holiday>();
			}
		}

        internal Table<Period> Period
		{
			get
			{
				return this.GetTable<Period>();
			}
		}

        internal Table<Resource> Resource
		{
			get
			{
				return this.GetTable<Resource>();
			}
		}

        internal Table<Task> Task
		{
			get
			{
				return this.GetTable<Task>();
			}
		}

        internal Table<Ticket> Ticket
		{
			get
			{
				return this.GetTable<Ticket>();
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
	
	[Table(Name="swt.cluster")]
	internal partial class Cluster : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
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
		
		[Column(Storage="_description", Name="Description", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_idcLuster", Name="IDCluster", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_shortDescription", Name="ShortDescription", DbType="varchar(10)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		[Association(Storage="_resource", OtherKey="DefaultCluster", ThisKey="IdcLuster", Name="fk_Resource_Cluster")]
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
		
		[Association(Storage="_ticket", OtherKey="IdcLuster", ThisKey="IdcLuster", Name="fk_Ticket_Cluster1")]
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
	
	[Table(Name="swt.excelrow")]
    internal partial class ExcelRow : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
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
		
		[Column(Storage="_date", Name="Date", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_description", Name="Description", DbType="varchar(4000)", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_endHour", Name="EndHour", DbType="time", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_ideXcelRow", Name="IDExcelRow", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_idpEriod", Name="IDPeriod", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_scpcHarged", Name="SCPCharged", DbType="tinyint(1)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_scphOurs", Name="SCPHours", DbType="decimal(2,1)", AutoSync=AutoSync.Never)]
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

        [Column(Storage = "_scpT", Name = "SCPT", DbType = "varchar(15)", AutoSync = AutoSync.Never)]
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
		
		[Column(Storage="_scptIcket", Name="SCPTicket", DbType="varchar(15)", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_startHour", Name="StartHour", DbType="time", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_t", Name="T", DbType="varchar(15)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_ticket", Name="Ticket", DbType="varchar(15)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
					if (_ticketTicket.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTicketChanging(value);
					this.SendPropertyChanging();
					this._ticket = value;
					this.SendPropertyChanged("Ticket");
					this.OnTicketChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_period", OtherKey="IdpEriod", ThisKey="IdpEriod", Name="fk_ExcelRow_Period1", IsForeignKey=true)]
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
		
		[Association(Storage="_resource", OtherKey="T", ThisKey="T", Name="fk_ExcelRow_Resource1", IsForeignKey=true)]
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
						_t = value.T;
					}
					else
					{
						_t = default(string);
					}
				}
			}
		}
		
		[Association(Storage="_ticketTicket", OtherKey="Number", ThisKey="Ticket", Name="fk_ExcelRow_Ticket1", IsForeignKey=true)]
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
						_ticket = value.Number;
					}
					else
					{
						_ticket = default(string);
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
	
	[Table(Name="swt.holiday")]
    internal partial class Holiday : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
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
		
		[Column(Storage="_date", Name="Date", DbType="datetime", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_description", Name="Description", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
	
	[Table(Name="swt.period")]
    internal partial class Period : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _description;
		
		private System.DateTime? _endDate;
		
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
		
		partial void OnEndDateChanging(System.DateTime? value);
		
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
		
		[Column(Storage="_description", Name="Description", DbType="varchar(20)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_endDate", Name="EndDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=true)]
		[DebuggerNonUserCode()]
		public System.DateTime? EndDate
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
		
		[Column(Storage="_idpEriod", Name="IDPeriod", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_month", Name="Month", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_startDate", Name="StartDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_year", Name="Year", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		[Association(Storage="_excelRow", OtherKey="IdpEriod", ThisKey="IdpEriod", Name="fk_ExcelRow_Period1")]
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
	
	[Table(Name="swt.resource")]
    internal partial class Resource : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _defaultCluster;
		
		private string _name;
		
		private string _t;
		
		private EntitySet<ExcelRow> _excelRow;
		
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
			_ticket = new EntitySet<Ticket>(new Action<Ticket>(this.Ticket_Attach), new Action<Ticket>(this.Ticket_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_defaultCluster", Name="DefaultCluster", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_name", Name="Name", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_t", Name="T", DbType="varchar(15)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		[Association(Storage="_excelRow", OtherKey="T", ThisKey="T", Name="fk_ExcelRow_Resource1")]
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
		
		[Association(Storage="_ticket", OtherKey="T", ThisKey="T", Name="fk_Ticket_Resource1")]
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
		[Association(Storage="_cluster", OtherKey="IdcLuster", ThisKey="DefaultCluster", Name="fk_Resource_Cluster", IsForeignKey=true)]
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
	
	[Table(Name="swt.task")]
    internal partial class Task : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _description;
		
		private System.Nullable<int> _donePercentage;
		
		private System.Nullable<decimal> _estimatedHours;
		
		private int _taskNumber;
		
		private string _ticketNumber;
		
		private string _title;
		
		private EntityRef<Ticket> _ticket = new EntityRef<Ticket>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDescriptionChanged();
		
		partial void OnDescriptionChanging(string value);
		
		partial void OnDonePercentageChanged();
		
		partial void OnDonePercentageChanging(System.Nullable<int> value);
		
		partial void OnEstimatedHoursChanged();
		
		partial void OnEstimatedHoursChanging(System.Nullable<decimal> value);
		
		partial void OnTaskNumberChanged();
		
		partial void OnTaskNumberChanging(int value);
		
		partial void OnTicketNumberChanged();
		
		partial void OnTicketNumberChanging(string value);
		
		partial void OnTitleChanged();
		
		partial void OnTitleChanging(string value);
		#endregion
		
		
		public Task()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_description", Name="Description", DbType="varchar(4000)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_donePercentage", Name="DonePercentage", DbType="int", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_estimatedHours", Name="EstimatedHours", DbType="decimal(2,1)", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_taskNumber", Name="TaskNumber", DbType="int", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_ticketNumber", Name="TicketNumber", DbType="varchar(15)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_title", Name="Title", DbType="varchar(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		#region Parents
		[Association(Storage="_ticket", OtherKey="Number", ThisKey="TicketNumber", Name="fk_Task_Ticket1", IsForeignKey=true)]
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
	
	[Table(Name="swt.ticket")]
    internal partial class Ticket : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private System.Nullable<System.DateTime> _deliveryDate;
		
		private int _idcLuster;
		
		private string _number;
		
		private System.Nullable<System.DateTime> _startDate;
		
		private string _t;
		
		private EntitySet<ExcelRow> _excelRow;
		
		private EntitySet<Task> _task;
		
		private EntityRef<Cluster> _cluster = new EntityRef<Cluster>();
		
		private EntityRef<Resource> _resource = new EntityRef<Resource>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDeliveryDateChanged();
		
		partial void OnDeliveryDateChanging(System.Nullable<System.DateTime> value);
		
		partial void OnIdcLusterChanged();
		
		partial void OnIdcLusterChanging(int value);
		
		partial void OnNumberChanged();
		
		partial void OnNumberChanging(string value);
		
		partial void OnStartDateChanged();
		
		partial void OnStartDateChanging(System.Nullable<System.DateTime> value);
		
		partial void OnTChanged();
		
		partial void OnTChanging(string value);
		#endregion
		
		
		public Ticket()
		{
			_excelRow = new EntitySet<ExcelRow>(new Action<ExcelRow>(this.ExcelRow_Attach), new Action<ExcelRow>(this.ExcelRow_Detach));
			_task = new EntitySet<Task>(new Action<Task>(this.Task_Attach), new Action<Task>(this.Task_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_deliveryDate", Name="DeliveryDate", DbType="datetime", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_idcLuster", Name="IDCluster", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_number", Name="Number", DbType="varchar(15)", IsPrimaryKey=true, AutoSync=AutoSync.Never, CanBeNull=false)]
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
		
		[Column(Storage="_startDate", Name="StartDate", DbType="datetime", AutoSync=AutoSync.Never)]
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
		
		[Column(Storage="_t", Name="T", DbType="varchar(15)", AutoSync=AutoSync.Never, CanBeNull=false)]
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
		[Association(Storage="_excelRow", OtherKey="Ticket", ThisKey="Number", Name="fk_ExcelRow_Ticket1")]
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
		
		[Association(Storage="_task", OtherKey="TicketNumber", ThisKey="Number", Name="fk_Task_Ticket1")]
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
		#endregion
		
		#region Parents
		[Association(Storage="_cluster", OtherKey="IdcLuster", ThisKey="IdcLuster", Name="fk_Ticket_Cluster1", IsForeignKey=true)]
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
		
		[Association(Storage="_resource", OtherKey="T", ThisKey="T", Name="fk_Ticket_Resource1", IsForeignKey=true)]
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
		#endregion
	}
}
