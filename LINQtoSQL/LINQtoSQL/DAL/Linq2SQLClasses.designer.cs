﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQtoSQL.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Linq2SQL")]
	public partial class Linq2SQLClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPerson(Person instance);
    partial void UpdatePerson(Person instance);
    partial void DeletePerson(Person instance);
    partial void InsertCountry(Country instance);
    partial void UpdateCountry(Country instance);
    partial void DeleteCountry(Country instance);
    partial void InsertCity(City instance);
    partial void UpdateCity(City instance);
    partial void DeleteCity(City instance);
    partial void InsertAddress(Address instance);
    partial void UpdateAddress(Address instance);
    partial void DeleteAddress(Address instance);
    #endregion
		
		public Linq2SQLClassesDataContext() : 
				base(global::LINQtoSQL.Settings.Default.Setting, mappingSource)
		{
			OnCreated();
		}
		
		public Linq2SQLClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Linq2SQLClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Linq2SQLClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Linq2SQLClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Person> Persons
		{
			get
			{
				return this.GetTable<Person>();
			}
		}
		
		public System.Data.Linq.Table<Country> Countries
		{
			get
			{
				return this.GetTable<Country>();
			}
		}
		
		public System.Data.Linq.Table<City> Cities
		{
			get
			{
				return this.GetTable<City>();
			}
		}
		
		public System.Data.Linq.Table<Address> Addresses
		{
			get
			{
				return this.GetTable<Address>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Person")]
	public partial class Person : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _surname;
		
		private string _firstname;
		
		private int _addressId;
		
		private EntityRef<Address> _Address;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnfirstnameChanging(string value);
    partial void OnfirstnameChanged();
    partial void OnaddressIdChanging(int value);
    partial void OnaddressIdChanged();
    #endregion
		
		public Person()
		{
			this._Address = default(EntityRef<Address>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string firstname
		{
			get
			{
				return this._firstname;
			}
			set
			{
				if ((this._firstname != value))
				{
					this.OnfirstnameChanging(value);
					this.SendPropertyChanging();
					this._firstname = value;
					this.SendPropertyChanged("firstname");
					this.OnfirstnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_addressId", DbType="Int NOT NULL")]
		public int addressId
		{
			get
			{
				return this._addressId;
			}
			set
			{
				if ((this._addressId != value))
				{
					if (this._Address.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnaddressIdChanging(value);
					this.SendPropertyChanging();
					this._addressId = value;
					this.SendPropertyChanged("addressId");
					this.OnaddressIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Address_Person", Storage="_Address", ThisKey="addressId", OtherKey="id", IsForeignKey=true)]
		public Address Address
		{
			get
			{
				return this._Address.Entity;
			}
			set
			{
				Address previousValue = this._Address.Entity;
				if (((previousValue != value) 
							|| (this._Address.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Address.Entity = null;
						previousValue.Persons.Remove(this);
					}
					this._Address.Entity = value;
					if ((value != null))
					{
						value.Persons.Add(this);
						this._addressId = value.id;
					}
					else
					{
						this._addressId = default(int);
					}
					this.SendPropertyChanged("Address");
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
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Country")]
	public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Address> _Addresses;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Country()
		{
			this._Addresses = new EntitySet<Address>(new Action<Address>(this.attach_Addresses), new Action<Address>(this.detach_Addresses));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Address", Storage="_Addresses", ThisKey="id", OtherKey="countryId")]
		public EntitySet<Address> Addresses
		{
			get
			{
				return this._Addresses;
			}
			set
			{
				this._Addresses.Assign(value);
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
		
		private void attach_Addresses(Address entity)
		{
			this.SendPropertyChanging();
			entity.Country = this;
		}
		
		private void detach_Addresses(Address entity)
		{
			this.SendPropertyChanging();
			entity.Country = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.City")]
	public partial class City : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Address> _Addresses;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public City()
		{
			this._Addresses = new EntitySet<Address>(new Action<Address>(this.attach_Addresses), new Action<Address>(this.detach_Addresses));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="City_Address", Storage="_Addresses", ThisKey="id", OtherKey="cityId")]
		public EntitySet<Address> Addresses
		{
			get
			{
				return this._Addresses;
			}
			set
			{
				this._Addresses.Assign(value);
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
		
		private void attach_Addresses(Address entity)
		{
			this.SendPropertyChanging();
			entity.City = this;
		}
		
		private void detach_Addresses(Address entity)
		{
			this.SendPropertyChanging();
			entity.City = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Address")]
	public partial class Address : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _buildingNumber;
		
		private int _dwellingNumber;
		
		private string _street;
		
		private int _cityId;
		
		private int _countryId;
		
		private EntitySet<Person> _Persons;
		
		private EntityRef<City> _City;
		
		private EntityRef<Country> _Country;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnbuildingNumberChanging(int value);
    partial void OnbuildingNumberChanged();
    partial void OndwellingNumberChanging(int value);
    partial void OndwellingNumberChanged();
    partial void OnstreetChanging(string value);
    partial void OnstreetChanged();
    partial void OncityIdChanging(int value);
    partial void OncityIdChanged();
    partial void OncountryIdChanging(int value);
    partial void OncountryIdChanged();
    #endregion
		
		public Address()
		{
			this._Persons = new EntitySet<Person>(new Action<Person>(this.attach_Persons), new Action<Person>(this.detach_Persons));
			this._City = default(EntityRef<City>);
			this._Country = default(EntityRef<Country>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_buildingNumber", DbType="Int NOT NULL")]
		public int buildingNumber
		{
			get
			{
				return this._buildingNumber;
			}
			set
			{
				if ((this._buildingNumber != value))
				{
					this.OnbuildingNumberChanging(value);
					this.SendPropertyChanging();
					this._buildingNumber = value;
					this.SendPropertyChanged("buildingNumber");
					this.OnbuildingNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dwellingNumber", DbType="Int NOT NULL")]
		public int dwellingNumber
		{
			get
			{
				return this._dwellingNumber;
			}
			set
			{
				if ((this._dwellingNumber != value))
				{
					this.OndwellingNumberChanging(value);
					this.SendPropertyChanging();
					this._dwellingNumber = value;
					this.SendPropertyChanged("dwellingNumber");
					this.OndwellingNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_street", DbType="VarChar(100)")]
		public string street
		{
			get
			{
				return this._street;
			}
			set
			{
				if ((this._street != value))
				{
					this.OnstreetChanging(value);
					this.SendPropertyChanging();
					this._street = value;
					this.SendPropertyChanged("street");
					this.OnstreetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cityId", DbType="Int NOT NULL")]
		public int cityId
		{
			get
			{
				return this._cityId;
			}
			set
			{
				if ((this._cityId != value))
				{
					if (this._City.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncityIdChanging(value);
					this.SendPropertyChanging();
					this._cityId = value;
					this.SendPropertyChanged("cityId");
					this.OncityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_countryId", DbType="Int NOT NULL")]
		public int countryId
		{
			get
			{
				return this._countryId;
			}
			set
			{
				if ((this._countryId != value))
				{
					if (this._Country.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncountryIdChanging(value);
					this.SendPropertyChanging();
					this._countryId = value;
					this.SendPropertyChanged("countryId");
					this.OncountryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Address_Person", Storage="_Persons", ThisKey="id", OtherKey="addressId")]
		public EntitySet<Person> Persons
		{
			get
			{
				return this._Persons;
			}
			set
			{
				this._Persons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="City_Address", Storage="_City", ThisKey="cityId", OtherKey="id", IsForeignKey=true)]
		public City City
		{
			get
			{
				return this._City.Entity;
			}
			set
			{
				City previousValue = this._City.Entity;
				if (((previousValue != value) 
							|| (this._City.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._City.Entity = null;
						previousValue.Addresses.Remove(this);
					}
					this._City.Entity = value;
					if ((value != null))
					{
						value.Addresses.Add(this);
						this._cityId = value.id;
					}
					else
					{
						this._cityId = default(int);
					}
					this.SendPropertyChanged("City");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Address", Storage="_Country", ThisKey="countryId", OtherKey="id", IsForeignKey=true)]
		public Country Country
		{
			get
			{
				return this._Country.Entity;
			}
			set
			{
				Country previousValue = this._Country.Entity;
				if (((previousValue != value) 
							|| (this._Country.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Country.Entity = null;
						previousValue.Addresses.Remove(this);
					}
					this._Country.Entity = value;
					if ((value != null))
					{
						value.Addresses.Add(this);
						this._countryId = value.id;
					}
					else
					{
						this._countryId = default(int);
					}
					this.SendPropertyChanged("Country");
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
		
		private void attach_Persons(Person entity)
		{
			this.SendPropertyChanging();
			entity.Address = this;
		}
		
		private void detach_Persons(Person entity)
		{
			this.SendPropertyChanging();
			entity.Address = null;
		}
	}
}
#pragma warning restore 1591
