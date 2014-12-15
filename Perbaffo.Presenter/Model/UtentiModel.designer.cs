﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Perbaffo.Presenter.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Perbaffo")]
	public partial class UtentiModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNewsletter(Newsletter instance);
    partial void UpdateNewsletter(Newsletter instance);
    partial void DeleteNewsletter(Newsletter instance);
    partial void InsertUtenti(Utenti instance);
    partial void UpdateUtenti(Utenti instance);
    partial void DeleteUtenti(Utenti instance);
    partial void InsertAmministratore(Amministratore instance);
    partial void UpdateAmministratore(Amministratore instance);
    partial void DeleteAmministratore(Amministratore instance);
    #endregion
		
		public UtentiModelDataContext() : 
				base(global::Perbaffo.Presenter.Properties.Settings.Default.PerbaffoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public UtentiModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UtentiModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UtentiModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public UtentiModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Newsletter> Newsletters
		{
			get
			{
				return this.GetTable<Newsletter>();
			}
		}
		
		public System.Data.Linq.Table<Utenti> Utentis
		{
			get
			{
				return this.GetTable<Utenti>();
			}
		}
		
		public System.Data.Linq.Table<Amministratore> Amministratores
		{
			get
			{
				return this.GetTable<Amministratore>();
			}
		}
		
		[Function(Name="dbo.GetNewId", IsComposable=true)]
		public System.Nullable<System.Guid> GetNewId()
		{
			return ((System.Nullable<System.Guid>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
	}
	
	[Table(Name="dbo.Newsletter")]
	[DataContract()]
	public partial class Newsletter : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _EMailNewsletter;
		
		private bool _NewsLetterGatti;
		
		private bool _NewsLetterCani;
		
		private bool _NewsLetterVolatili;
		
		private bool _NewsLetterRoditori;
		
		private bool _NewsLetterRettili;
		
		private bool _NewsLetterAcquarologia;
		
		private bool _Attivo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnEMailNewsletterChanging(string value);
    partial void OnEMailNewsletterChanged();
    partial void OnNewsLetterGattiChanging(bool value);
    partial void OnNewsLetterGattiChanged();
    partial void OnNewsLetterCaniChanging(bool value);
    partial void OnNewsLetterCaniChanged();
    partial void OnNewsLetterVolatiliChanging(bool value);
    partial void OnNewsLetterVolatiliChanged();
    partial void OnNewsLetterRoditoriChanging(bool value);
    partial void OnNewsLetterRoditoriChanged();
    partial void OnNewsLetterRettiliChanging(bool value);
    partial void OnNewsLetterRettiliChanged();
    partial void OnNewsLetterAcquarologiaChanging(bool value);
    partial void OnNewsLetterAcquarologiaChanged();
    partial void OnAttivoChanging(bool value);
    partial void OnAttivoChanged();
    #endregion
		
		public Newsletter()
		{
			this.Initialize();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[DataMember(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_EMailNewsletter", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=2)]
		public string EMailNewsletter
		{
			get
			{
				return this._EMailNewsletter;
			}
			set
			{
				if ((this._EMailNewsletter != value))
				{
					this.OnEMailNewsletterChanging(value);
					this.SendPropertyChanging();
					this._EMailNewsletter = value;
					this.SendPropertyChanged("EMailNewsletter");
					this.OnEMailNewsletterChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterGatti", DbType="Bit NOT NULL")]
		[DataMember(Order=3)]
		public bool NewsLetterGatti
		{
			get
			{
				return this._NewsLetterGatti;
			}
			set
			{
				if ((this._NewsLetterGatti != value))
				{
					this.OnNewsLetterGattiChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterGatti = value;
					this.SendPropertyChanged("NewsLetterGatti");
					this.OnNewsLetterGattiChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterCani", DbType="Bit NOT NULL")]
		[DataMember(Order=4)]
		public bool NewsLetterCani
		{
			get
			{
				return this._NewsLetterCani;
			}
			set
			{
				if ((this._NewsLetterCani != value))
				{
					this.OnNewsLetterCaniChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterCani = value;
					this.SendPropertyChanged("NewsLetterCani");
					this.OnNewsLetterCaniChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterVolatili", DbType="Bit NOT NULL")]
		[DataMember(Order=5)]
		public bool NewsLetterVolatili
		{
			get
			{
				return this._NewsLetterVolatili;
			}
			set
			{
				if ((this._NewsLetterVolatili != value))
				{
					this.OnNewsLetterVolatiliChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterVolatili = value;
					this.SendPropertyChanged("NewsLetterVolatili");
					this.OnNewsLetterVolatiliChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterRoditori", DbType="Bit NOT NULL")]
		[DataMember(Order=6)]
		public bool NewsLetterRoditori
		{
			get
			{
				return this._NewsLetterRoditori;
			}
			set
			{
				if ((this._NewsLetterRoditori != value))
				{
					this.OnNewsLetterRoditoriChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterRoditori = value;
					this.SendPropertyChanged("NewsLetterRoditori");
					this.OnNewsLetterRoditoriChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterRettili", DbType="Bit NOT NULL")]
		[DataMember(Order=7)]
		public bool NewsLetterRettili
		{
			get
			{
				return this._NewsLetterRettili;
			}
			set
			{
				if ((this._NewsLetterRettili != value))
				{
					this.OnNewsLetterRettiliChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterRettili = value;
					this.SendPropertyChanged("NewsLetterRettili");
					this.OnNewsLetterRettiliChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterAcquarologia", DbType="Bit NOT NULL")]
		[DataMember(Order=8)]
		public bool NewsLetterAcquarologia
		{
			get
			{
				return this._NewsLetterAcquarologia;
			}
			set
			{
				if ((this._NewsLetterAcquarologia != value))
				{
					this.OnNewsLetterAcquarologiaChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterAcquarologia = value;
					this.SendPropertyChanged("NewsLetterAcquarologia");
					this.OnNewsLetterAcquarologiaChanged();
				}
			}
		}
		
		[Column(Storage="_Attivo", DbType="Bit NOT NULL")]
		[DataMember(Order=9)]
		public bool Attivo
		{
			get
			{
				return this._Attivo;
			}
			set
			{
				if ((this._Attivo != value))
				{
					this.OnAttivoChanging(value);
					this.SendPropertyChanging();
					this._Attivo = value;
					this.SendPropertyChanged("Attivo");
					this.OnAttivoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[OnDeserializing()]
		[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[Table(Name="dbo.Utenti")]
	[DataContract()]
	public partial class Utenti : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Nome;
		
		private string _Cognome;
		
		private string _CFiscPIva;
		
		private string _Citta;
		
		private string _Provincia;
		
		private string _EMail;
		
		private string _Telefono;
		
		private string _RagioneSociale;
		
		private string _CAP;
		
		private System.DateTime _DataNascita;
		
		private string _NumeroCivico;
		
		private string _Password;
		
		private string _NotePerbaffo;
		
		private string _Indirizzo;
		
		private System.DateTime _DataCreazioneUtente;
		
		private System.DateTime _DataLastLogin;
		
		private bool _NewsLetterGatti;
		
		private bool _NewsLetterCani;
		
		private bool _NewsLetterVolatili;
		
		private bool _NewsLetterRoditori;
		
		private bool _NewsLetterRettili;
		
		private bool _NewsLetterAcquarologia;
		
		private bool _IsAttivo;
		
		private string _ImgFriend;
		
		private string _NomeFriend;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnCognomeChanging(string value);
    partial void OnCognomeChanged();
    partial void OnCFiscPIvaChanging(string value);
    partial void OnCFiscPIvaChanged();
    partial void OnCittaChanging(string value);
    partial void OnCittaChanged();
    partial void OnProvinciaChanging(string value);
    partial void OnProvinciaChanged();
    partial void OnEMailChanging(string value);
    partial void OnEMailChanged();
    partial void OnTelefonoChanging(string value);
    partial void OnTelefonoChanged();
    partial void OnRagioneSocialeChanging(string value);
    partial void OnRagioneSocialeChanged();
    partial void OnCAPChanging(string value);
    partial void OnCAPChanged();
    partial void OnDataNascitaChanging(System.DateTime value);
    partial void OnDataNascitaChanged();
    partial void OnNumeroCivicoChanging(string value);
    partial void OnNumeroCivicoChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnNotePerbaffoChanging(string value);
    partial void OnNotePerbaffoChanged();
    partial void OnIndirizzoChanging(string value);
    partial void OnIndirizzoChanged();
    partial void OnDataCreazioneUtenteChanging(System.DateTime value);
    partial void OnDataCreazioneUtenteChanged();
    partial void OnDataLastLoginChanging(System.DateTime value);
    partial void OnDataLastLoginChanged();
    partial void OnNewsLetterGattiChanging(bool value);
    partial void OnNewsLetterGattiChanged();
    partial void OnNewsLetterCaniChanging(bool value);
    partial void OnNewsLetterCaniChanged();
    partial void OnNewsLetterVolatiliChanging(bool value);
    partial void OnNewsLetterVolatiliChanged();
    partial void OnNewsLetterRoditoriChanging(bool value);
    partial void OnNewsLetterRoditoriChanged();
    partial void OnNewsLetterRettiliChanging(bool value);
    partial void OnNewsLetterRettiliChanged();
    partial void OnNewsLetterAcquarologiaChanging(bool value);
    partial void OnNewsLetterAcquarologiaChanged();
    partial void OnIsAttivoChanging(bool value);
    partial void OnIsAttivoChanged();
    partial void OnImgFriendChanging(string value);
    partial void OnImgFriendChanged();
    partial void OnNomeFriendChanging(string value);
    partial void OnNomeFriendChanged();
    #endregion
		
		public Utenti()
		{
			this.Initialize();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[DataMember(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=2)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Column(Storage="_Cognome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=3)]
		public string Cognome
		{
			get
			{
				return this._Cognome;
			}
			set
			{
				if ((this._Cognome != value))
				{
					this.OnCognomeChanging(value);
					this.SendPropertyChanging();
					this._Cognome = value;
					this.SendPropertyChanged("Cognome");
					this.OnCognomeChanged();
				}
			}
		}
		
		[Column(Storage="_CFiscPIva", DbType="VarChar(16) NOT NULL", CanBeNull=false)]
		[DataMember(Order=4)]
		public string CFiscPIva
		{
			get
			{
				return this._CFiscPIva;
			}
			set
			{
				if ((this._CFiscPIva != value))
				{
					this.OnCFiscPIvaChanging(value);
					this.SendPropertyChanging();
					this._CFiscPIva = value;
					this.SendPropertyChanged("CFiscPIva");
					this.OnCFiscPIvaChanged();
				}
			}
		}
		
		[Column(Storage="_Citta", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		[DataMember(Order=5)]
		public string Citta
		{
			get
			{
				return this._Citta;
			}
			set
			{
				if ((this._Citta != value))
				{
					this.OnCittaChanging(value);
					this.SendPropertyChanging();
					this._Citta = value;
					this.SendPropertyChanged("Citta");
					this.OnCittaChanged();
				}
			}
		}
		
		[Column(Storage="_Provincia", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		[DataMember(Order=6)]
		public string Provincia
		{
			get
			{
				return this._Provincia;
			}
			set
			{
				if ((this._Provincia != value))
				{
					this.OnProvinciaChanging(value);
					this.SendPropertyChanging();
					this._Provincia = value;
					this.SendPropertyChanged("Provincia");
					this.OnProvinciaChanged();
				}
			}
		}
		
		[Column(Storage="_EMail", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=7)]
		public string EMail
		{
			get
			{
				return this._EMail;
			}
			set
			{
				if ((this._EMail != value))
				{
					this.OnEMailChanging(value);
					this.SendPropertyChanging();
					this._EMail = value;
					this.SendPropertyChanged("EMail");
					this.OnEMailChanged();
				}
			}
		}
		
		[Column(Storage="_Telefono", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=8)]
		public string Telefono
		{
			get
			{
				return this._Telefono;
			}
			set
			{
				if ((this._Telefono != value))
				{
					this.OnTelefonoChanging(value);
					this.SendPropertyChanging();
					this._Telefono = value;
					this.SendPropertyChanged("Telefono");
					this.OnTelefonoChanged();
				}
			}
		}
		
		[Column(Storage="_RagioneSociale", DbType="VarChar(150)")]
		[DataMember(Order=9)]
		public string RagioneSociale
		{
			get
			{
				return this._RagioneSociale;
			}
			set
			{
				if ((this._RagioneSociale != value))
				{
					this.OnRagioneSocialeChanging(value);
					this.SendPropertyChanging();
					this._RagioneSociale = value;
					this.SendPropertyChanged("RagioneSociale");
					this.OnRagioneSocialeChanged();
				}
			}
		}
		
		[Column(Storage="_CAP", DbType="Varchar(5) NOT NULL", CanBeNull=false)]
		[DataMember(Order=10)]
		public string CAP
		{
			get
			{
				return this._CAP;
			}
			set
			{
				if ((this._CAP != value))
				{
					this.OnCAPChanging(value);
					this.SendPropertyChanging();
					this._CAP = value;
					this.SendPropertyChanged("CAP");
					this.OnCAPChanged();
				}
			}
		}
		
		[Column(Storage="_DataNascita", DbType="DateTime NOT NULL")]
		[DataMember(Order=11)]
		public System.DateTime DataNascita
		{
			get
			{
				return this._DataNascita;
			}
			set
			{
				if ((this._DataNascita != value))
				{
					this.OnDataNascitaChanging(value);
					this.SendPropertyChanging();
					this._DataNascita = value;
					this.SendPropertyChanged("DataNascita");
					this.OnDataNascitaChanged();
				}
			}
		}
		
		[Column(Storage="_NumeroCivico", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=12)]
		public string NumeroCivico
		{
			get
			{
				return this._NumeroCivico;
			}
			set
			{
				if ((this._NumeroCivico != value))
				{
					this.OnNumeroCivicoChanging(value);
					this.SendPropertyChanging();
					this._NumeroCivico = value;
					this.SendPropertyChanged("NumeroCivico");
					this.OnNumeroCivicoChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		[DataMember(Order=13)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_NotePerbaffo", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		[DataMember(Order=14)]
		public string NotePerbaffo
		{
			get
			{
				return this._NotePerbaffo;
			}
			set
			{
				if ((this._NotePerbaffo != value))
				{
					this.OnNotePerbaffoChanging(value);
					this.SendPropertyChanging();
					this._NotePerbaffo = value;
					this.SendPropertyChanged("NotePerbaffo");
					this.OnNotePerbaffoChanged();
				}
			}
		}
		
		[Column(Storage="_Indirizzo", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		[DataMember(Order=15)]
		public string Indirizzo
		{
			get
			{
				return this._Indirizzo;
			}
			set
			{
				if ((this._Indirizzo != value))
				{
					this.OnIndirizzoChanging(value);
					this.SendPropertyChanging();
					this._Indirizzo = value;
					this.SendPropertyChanged("Indirizzo");
					this.OnIndirizzoChanged();
				}
			}
		}
		
		[Column(Storage="_DataCreazioneUtente", DbType="DateTime NOT NULL")]
		[DataMember(Order=16)]
		public System.DateTime DataCreazioneUtente
		{
			get
			{
				return this._DataCreazioneUtente;
			}
			set
			{
				if ((this._DataCreazioneUtente != value))
				{
					this.OnDataCreazioneUtenteChanging(value);
					this.SendPropertyChanging();
					this._DataCreazioneUtente = value;
					this.SendPropertyChanged("DataCreazioneUtente");
					this.OnDataCreazioneUtenteChanged();
				}
			}
		}
		
		[Column(Storage="_DataLastLogin", DbType="DateTime NOT NULL")]
		[DataMember(Order=17)]
		public System.DateTime DataLastLogin
		{
			get
			{
				return this._DataLastLogin;
			}
			set
			{
				if ((this._DataLastLogin != value))
				{
					this.OnDataLastLoginChanging(value);
					this.SendPropertyChanging();
					this._DataLastLogin = value;
					this.SendPropertyChanged("DataLastLogin");
					this.OnDataLastLoginChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterGatti", DbType="Bit NOT NULL")]
		[DataMember(Order=18)]
		public bool NewsLetterGatti
		{
			get
			{
				return this._NewsLetterGatti;
			}
			set
			{
				if ((this._NewsLetterGatti != value))
				{
					this.OnNewsLetterGattiChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterGatti = value;
					this.SendPropertyChanged("NewsLetterGatti");
					this.OnNewsLetterGattiChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterCani", DbType="Bit NOT NULL")]
		[DataMember(Order=19)]
		public bool NewsLetterCani
		{
			get
			{
				return this._NewsLetterCani;
			}
			set
			{
				if ((this._NewsLetterCani != value))
				{
					this.OnNewsLetterCaniChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterCani = value;
					this.SendPropertyChanged("NewsLetterCani");
					this.OnNewsLetterCaniChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterVolatili", DbType="Bit NOT NULL")]
		[DataMember(Order=20)]
		public bool NewsLetterVolatili
		{
			get
			{
				return this._NewsLetterVolatili;
			}
			set
			{
				if ((this._NewsLetterVolatili != value))
				{
					this.OnNewsLetterVolatiliChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterVolatili = value;
					this.SendPropertyChanged("NewsLetterVolatili");
					this.OnNewsLetterVolatiliChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterRoditori", DbType="Bit NOT NULL")]
		[DataMember(Order=21)]
		public bool NewsLetterRoditori
		{
			get
			{
				return this._NewsLetterRoditori;
			}
			set
			{
				if ((this._NewsLetterRoditori != value))
				{
					this.OnNewsLetterRoditoriChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterRoditori = value;
					this.SendPropertyChanged("NewsLetterRoditori");
					this.OnNewsLetterRoditoriChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterRettili", DbType="Bit NOT NULL")]
		[DataMember(Order=22)]
		public bool NewsLetterRettili
		{
			get
			{
				return this._NewsLetterRettili;
			}
			set
			{
				if ((this._NewsLetterRettili != value))
				{
					this.OnNewsLetterRettiliChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterRettili = value;
					this.SendPropertyChanged("NewsLetterRettili");
					this.OnNewsLetterRettiliChanged();
				}
			}
		}
		
		[Column(Storage="_NewsLetterAcquarologia", DbType="Bit NOT NULL")]
		[DataMember(Order=23)]
		public bool NewsLetterAcquarologia
		{
			get
			{
				return this._NewsLetterAcquarologia;
			}
			set
			{
				if ((this._NewsLetterAcquarologia != value))
				{
					this.OnNewsLetterAcquarologiaChanging(value);
					this.SendPropertyChanging();
					this._NewsLetterAcquarologia = value;
					this.SendPropertyChanged("NewsLetterAcquarologia");
					this.OnNewsLetterAcquarologiaChanged();
				}
			}
		}
		
		[Column(Storage="_IsAttivo", DbType="Bit NOT NULL")]
		[DataMember(Order=24)]
		public bool IsAttivo
		{
			get
			{
				return this._IsAttivo;
			}
			set
			{
				if ((this._IsAttivo != value))
				{
					this.OnIsAttivoChanging(value);
					this.SendPropertyChanging();
					this._IsAttivo = value;
					this.SendPropertyChanged("IsAttivo");
					this.OnIsAttivoChanged();
				}
			}
		}
		
		[Column(Storage="_ImgFriend", DbType="VarChar(30)")]
		[DataMember(Order=25)]
		public string ImgFriend
		{
			get
			{
				return this._ImgFriend;
			}
			set
			{
				if ((this._ImgFriend != value))
				{
					this.OnImgFriendChanging(value);
					this.SendPropertyChanging();
					this._ImgFriend = value;
					this.SendPropertyChanged("ImgFriend");
					this.OnImgFriendChanged();
				}
			}
		}
		
		[Column(Storage="_NomeFriend", DbType="VarChar(100)")]
		[DataMember(Order=26)]
		public string NomeFriend
		{
			get
			{
				return this._NomeFriend;
			}
			set
			{
				if ((this._NomeFriend != value))
				{
					this.OnNomeFriendChanging(value);
					this.SendPropertyChanging();
					this._NomeFriend = value;
					this.SendPropertyChanged("NomeFriend");
					this.OnNomeFriendChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[OnDeserializing()]
		[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[Table(Name="dbo.Amministratore")]
	[DataContract()]
	public partial class Amministratore : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Nome;
		
		private string _Cognome;
		
		private string _Username;
		
		private string _Password;
		
		private System.DateTime _DataCreazione;
		
		private System.DateTime _DataUltimoLogin;
		
		private System.DateTime _DataLogin;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnCognomeChanging(string value);
    partial void OnCognomeChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnDataCreazioneChanging(System.DateTime value);
    partial void OnDataCreazioneChanged();
    partial void OnDataUltimoLoginChanging(System.DateTime value);
    partial void OnDataUltimoLoginChanged();
    partial void OnDataLoginChanging(System.DateTime value);
    partial void OnDataLoginChanged();
    #endregion
		
		public Amministratore()
		{
			this.Initialize();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[DataMember(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=2)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Column(Storage="_Cognome", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[DataMember(Order=3)]
		public string Cognome
		{
			get
			{
				return this._Cognome;
			}
			set
			{
				if ((this._Cognome != value))
				{
					this.OnCognomeChanging(value);
					this.SendPropertyChanging();
					this._Cognome = value;
					this.SendPropertyChanged("Cognome");
					this.OnCognomeChanged();
				}
			}
		}
		
		[Column(Storage="_Username", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		[DataMember(Order=4)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		[DataMember(Order=5)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_DataCreazione", DbType="DateTime NOT NULL")]
		[DataMember(Order=6)]
		public System.DateTime DataCreazione
		{
			get
			{
				return this._DataCreazione;
			}
			set
			{
				if ((this._DataCreazione != value))
				{
					this.OnDataCreazioneChanging(value);
					this.SendPropertyChanging();
					this._DataCreazione = value;
					this.SendPropertyChanged("DataCreazione");
					this.OnDataCreazioneChanged();
				}
			}
		}
		
		[Column(Storage="_DataUltimoLogin", DbType="DateTime NOT NULL")]
		[DataMember(Order=7)]
		public System.DateTime DataUltimoLogin
		{
			get
			{
				return this._DataUltimoLogin;
			}
			set
			{
				if ((this._DataUltimoLogin != value))
				{
					this.OnDataUltimoLoginChanging(value);
					this.SendPropertyChanging();
					this._DataUltimoLogin = value;
					this.SendPropertyChanged("DataUltimoLogin");
					this.OnDataUltimoLoginChanged();
				}
			}
		}
		
		[Column(Storage="_DataLogin", DbType="DateTime NOT NULL")]
		[DataMember(Order=8)]
		public System.DateTime DataLogin
		{
			get
			{
				return this._DataLogin;
			}
			set
			{
				if ((this._DataLogin != value))
				{
					this.OnDataLoginChanging(value);
					this.SendPropertyChanging();
					this._DataLogin = value;
					this.SendPropertyChanged("DataLogin");
					this.OnDataLoginChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[OnDeserializing()]
		[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
}
#pragma warning restore 1591