﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgendaREST.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AgendaCompromissoDB")]
	public partial class AgendaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCompromisso(Compromisso instance);
    partial void UpdateCompromisso(Compromisso instance);
    partial void DeleteCompromisso(Compromisso instance);
    #endregion
		
		public AgendaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AgendaCompromissoDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AgendaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgendaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgendaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AgendaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Compromisso> Compromissos
		{
			get
			{
				return this.GetTable<Compromisso>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Compromisso")]
	public partial class Compromisso : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Descricao;
		
		private string _Local;
		
		private System.Nullable<System.DateTime> _Data;
		
		private System.Nullable<bool> _Realizado;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDescricaoChanging(string value);
    partial void OnDescricaoChanged();
    partial void OnLocalChanging(string value);
    partial void OnLocalChanged();
    partial void OnDataChanging(System.Nullable<System.DateTime> value);
    partial void OnDataChanged();
    partial void OnRealizadoChanging(System.Nullable<bool> value);
    partial void OnRealizadoChanged();
    #endregion
		
		public Compromisso()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descricao", DbType="VarChar(50)")]
		public string Descricao
		{
			get
			{
				return this._Descricao;
			}
			set
			{
				if ((this._Descricao != value))
				{
					this.OnDescricaoChanging(value);
					this.SendPropertyChanging();
					this._Descricao = value;
					this.SendPropertyChanged("Descricao");
					this.OnDescricaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Local", DbType="VarChar(50)")]
		public string Local
		{
			get
			{
				return this._Local;
			}
			set
			{
				if ((this._Local != value))
				{
					this.OnLocalChanging(value);
					this.SendPropertyChanging();
					this._Local = value;
					this.SendPropertyChanged("Local");
					this.OnLocalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="DateTime")]
		public System.Nullable<System.DateTime> Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Realizado", DbType="Bit")]
		public System.Nullable<bool> Realizado
		{
			get
			{
				return this._Realizado;
			}
			set
			{
				if ((this._Realizado != value))
				{
					this.OnRealizadoChanging(value);
					this.SendPropertyChanging();
					this._Realizado = value;
					this.SendPropertyChanged("Realizado");
					this.OnRealizadoChanged();
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
}
#pragma warning restore 1591
