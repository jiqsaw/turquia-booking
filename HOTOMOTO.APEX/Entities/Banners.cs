using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class Banners {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intBannerID;
		private SqlInt32 m_intBannerPositionID;
		private SqlInt32 m_intBannerFileTypeID;
		private SqlInt32 m_intWidth;
		private SqlInt32 m_intHeight;
		private SqlDateTime m_dtCreateDate;
		private SqlInt32 m_intCreatedBy;
		private SqlDateTime m_dtModifyDate;
		private SqlInt32 m_intModifiedBy;
// members from ml table
private int m_intLanguageID;
		private Dictionary<int, SqlString> m_strTitle;
		private Dictionary<int, SqlString> m_strDescription;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public Banners() {
			Init();	//	init Object	
				
			m_strTitle = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();
		}
		
			
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Banners(int LanguageID) {
			Init();	//	init Object
			
			this.m_intLanguageID = LanguageID;
							
			m_strTitle = new Dictionary<int, SqlString>();				
			m_strDescription = new Dictionary<int, SqlString>();
		}

		/// <summary>
		/// Gets all Banners from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the Banners</returns>
		public static SqlDataReader GetAllBannersReader(int LanguageID) {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Banners__sel_all", conn);

			SqlParameter param;
			// parameter for LanguageID column
        	param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        	param.Direction = ParameterDirection.Input;
        	param.Value = LanguageID;
        	cmd.Parameters.Add(param);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllBannersDataSet(int LanguageID) {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_Banners__sel_all", conn);


			SqlParameter param;
			// parameter for LanguageID column
        	param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        	param.Direction = ParameterDirection.Input;
        	param.Value = LanguageID;
        	cmd.Parameters.Add(param);

            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all Banners from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllBanners(int LanguageID) {
			SqlDataReader dr = GetAllBannersReader(LanguageID);
			return ConvertReaderToHashTable(dr, LanguageID);
		}
		
		/// <summary>
		/// Creates Banners for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the Banners records</param>
		/// <returns>The Hashtable containing Banners objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr, int LanguageID) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            Banners myBanners = new Banners(LanguageID);
            
            myBanners.m_intBannerID = dr.GetSqlInt32(0);
            myBanners.m_intBannerPositionID = dr.GetSqlInt32(1);
            myBanners.m_intBannerFileTypeID = dr.GetSqlInt32(2);
            myBanners.m_intWidth = dr.GetSqlInt32(3);
            myBanners.m_intHeight = dr.GetSqlInt32(4);
            myBanners.m_dtCreateDate = dr.GetSqlDateTime(5);
            myBanners.m_intCreatedBy = dr.GetSqlInt32(6);
            myBanners.m_dtModifyDate = dr.GetSqlDateTime(7);
            myBanners.m_intModifiedBy = dr.GetSqlInt32(8);
            
            result.Add(myBanners.BannerID, myBanners);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 BannerID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.BannerID = m_intBannerID;
				return pk;
			}
		}
			/// <summary>
		/// The BannerID column in the DB
		/// </summary>
		public int BannerID {
			get {
				return (int)m_intBannerID;
			}
			set {
				m_intBannerID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BannerPositionID column in the DB
		/// </summary>
		public int BannerPositionID {
			get {
				return (int)m_intBannerPositionID;
			}
			set {
				m_intBannerPositionID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The BannerFileTypeID column in the DB
		/// </summary>
		public int BannerFileTypeID {
			get {
				return (int)m_intBannerFileTypeID;
			}
			set {
				m_intBannerFileTypeID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Width column in the DB
		/// </summary>
		public int Width {
			get {
				return (int)m_intWidth;
			}
			set {
				m_intWidth = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Height column in the DB
		/// </summary>
		public int Height {
			get {
				return (int)m_intHeight;
			}
			set {
				m_intHeight = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CreateDate column in the DB
		/// </summary>
		public DateTime CreateDate {
			get {
				return (DateTime)m_dtCreateDate;
			}
			set {
				m_dtCreateDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CreatedBy column in the DB
		/// </summary>
		public int CreatedBy {
			get {
				return (int)m_intCreatedBy;
			}
			set {
				m_intCreatedBy = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ModifyDate column in the DB
		/// </summary>
		public DateTime ModifyDate {
			get {
				return (DateTime)m_dtModifyDate;
			}
			set {
				m_dtModifyDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ModifiedBy column in the DB
		/// </summary>
		public int ModifiedBy {
			get {
				return (int)m_intModifiedBy;
			}
			set {
				m_intModifiedBy = value;
				m_bIsDirty = true;
			}
		}
			
		public int LanguageID {
			get { 
				return m_intLanguageID; 
			}
			set {
				m_intLanguageID = value;
			}
		}
							
		/// <summary>
		/// The Title column from ML table
		/// </summary>
		public string Title {
			get { 
				return this.GetTitle(this.m_intLanguageID); 
			}
			set { 
				this.SetTitle(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public string Description {
			get { 
				return this.GetDescription(this.m_intLanguageID); 
			}
			set { 
				this.SetDescription(value, this.m_intLanguageID);
                this.m_bIsDirty = true;
			}
		}
								
		/// <summary>
		/// The Title column from ML table
		/// </summary>
		public string GetTitle(int LanguageID) {
			return this.m_strTitle[LanguageID].Value;
		}
		
		/// <summary>
		/// The Title column from ML table
		/// </summary>
		public void SetTitle(string Title, int LanguageID) {
			this.m_strTitle[LanguageID] = Title;
		}
		
								
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public string GetDescription(int LanguageID) {
			return this.m_strDescription[LanguageID].Value;
		}
		
		/// <summary>
		/// The Description column from ML table
		/// </summary>
		public void SetDescription(string Description, int LanguageID) {
			this.m_strDescription[LanguageID] = Description;
		}
		
					/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.BannerID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intBannerID"> BannerID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intBannerID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_Banners__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for BannerID column
        param = new SqlParameter("@BannerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intBannerID;
        cmd.Parameters.Add(param);
        
		//	open connection
				conn.Open();
				//	Execute command And get reader
				SqlDataReader reader = cmd.ExecuteReader();
		
				bool found = false;	//	false solution
		
				//	check if  anything was found
				if(reader.Read()) {
					found = true;	//	corresponding row found
					m_aAction = Action.Update;	//	future action
		
					//	set member values
		            m_intBannerID = reader.GetSqlInt32(0);
            m_intBannerPositionID = reader.GetSqlInt32(1);
            m_intBannerFileTypeID = reader.GetSqlInt32(2);
            m_intWidth = reader.GetSqlInt32(3);
            m_intHeight = reader.GetSqlInt32(4);
            m_dtCreateDate = reader.GetSqlDateTime(5);
            m_intCreatedBy = reader.GetSqlInt32(6);
            m_dtModifyDate = reader.GetSqlDateTime(7);
            m_intModifiedBy = reader.GetSqlInt32(8);
		
			
				cmd = DBHelper.getSprocCmd("proc_Banners__sel_ml_data", conn);
				
				            // parameter for BannerID column
            param = new SqlParameter("@BannerID", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Input;
            param.Value = intBannerID;
            cmd.Parameters.Add(param);
            
			
				reader.Close();
				reader = null;
				
				if(conn.State == ConnectionState.Closed) conn.Open();
				
				reader = cmd.ExecuteReader();

				//check if  anything was found
				while(reader.Read()) { 			
			m_strTitle.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(2));			
			m_strDescription.Add((int)reader.GetSqlInt32(1), (SqlString)reader.GetSqlString(3));				}
				
			} else {
					//	set key values
		            m_intBannerID = intBannerID;
	}
		
			//	close connection
			conn.Close();
			//	set dirty flag To false
			m_bIsDirty = false;
			//	return true if  a row found, otherwise false
			return found;
			
		}
		
		/// <summary>
		/// Updates the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Save() {
			int retValue;
			switch(m_aAction) {
				case Action.Insert:
					//	insert row
					retValue = ins();
					//	future action To be update
					m_aAction = Action.Update;
					//	return retValue from insert
					return retValue;
				case Action.Update:
					//	check if  Objectstringdirty
					if (m_bIsDirty)	{
						//	update row And return retValue
						return upd();
					} else {
						//	return 0 (all ok)
						return 0;
					}
				case Action.Delete:
					//	delete row
					retValue = del();
					//	future action To be insert
					m_aAction = Action.Insert;
					//	return retValue from delete
					return retValue;
			}
	
			throw new System.Exception("Unknown action.");
		}
	
		/// <summary>
		/// Updates the DB with transaction.
		/// </summary>
		/// <returns>0 if success</returns>	
		public int Save(SqlTransaction transaction) {	
            this.m_Transaction = transaction;
            return this.Save();
		}	
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete() {
			m_aAction = Action.Delete;	//	actionstringdelete
			return Save();
		}
	
		/// <summary>
		/// Deletes the Object from the DB with transaction.
		/// </summary>
		/// <returns>0 if success</returns>
		public int Delete(SqlTransaction transaction) {
			m_aAction = Action.Delete;       //            actionstringdelete
			return Save(transaction);
		}
	
		//	private member functions
	
		/// <summary>
		/// Adds the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int ins() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
							cmd = DBHelper.getSprocCmd("proc_Banners__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_Banners__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for BannerID column
        param = new SqlParameter("@BannerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerID;
        cmd.Parameters.Add(param);
        
        // parameter for BannerPositionID column
        param = new SqlParameter("@BannerPositionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerPositionID;
        cmd.Parameters.Add(param);
        
        // parameter for BannerFileTypeID column
        param = new SqlParameter("@BannerFileTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerFileTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for Width column
        param = new SqlParameter("@Width", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intWidth;
        cmd.Parameters.Add(param);
        
        // parameter for Height column
        param = new SqlParameter("@Height", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHeight;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
        cmd.Parameters.Add(param);
        
		
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
								foreach(int langID in this.m_strDescription.Keys) {
						Banners_ML.Insert(retValue, langID, this.m_strTitle[langID].ToString(), this.m_strDescription[langID].ToString());
					}
						
			//	set dirty flag To false
			m_bIsDirty = false;
		
			return retValue;
		}
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_Banners__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Banners__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for BannerID column
        param = new SqlParameter("@BannerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerID;
        cmd.Parameters.Add(param);
        
        // parameter for BannerPositionID column
        param = new SqlParameter("@BannerPositionID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerPositionID;
        cmd.Parameters.Add(param);
        
        // parameter for BannerFileTypeID column
        param = new SqlParameter("@BannerFileTypeID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerFileTypeID;
        cmd.Parameters.Add(param);
        
        // parameter for Width column
        param = new SqlParameter("@Width", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intWidth;
        cmd.Parameters.Add(param);
        
        // parameter for Height column
        param = new SqlParameter("@Height", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intHeight;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for CreatedBy column
        param = new SqlParameter("@CreatedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCreatedBy;
        cmd.Parameters.Add(param);
        
        // parameter for ModifyDate column
        param = new SqlParameter("@ModifyDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtModifyDate;
        cmd.Parameters.Add(param);
        
        // parameter for ModifiedBy column
        param = new SqlParameter("@ModifiedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intModifiedBy;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			
			//	close connection
			conn.Close();
			
			
								Banners_ML objBanners_ML = new Banners_ML();
					foreach(int langID in this.m_strDescription.Keys) {
						objBanners_ML.BannerID = (int)this.m_intBannerID;
						objBanners_ML.LanguageID = langID;
						objBanners_ML.Title = this.m_strTitle[langID].ToString();
objBanners_ML.Description = this.m_strDescription[langID].ToString();
 objBanners_ML.Update();
					}
							
			
		
			//	set dirty flag To false
			m_bIsDirty = false;
		
			return retValue;
		}
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int del() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_Banners__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_Banners__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for BannerID column
        param = new SqlParameter("@BannerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intBannerID;
        cmd.Parameters.Add(param);
        
			//	open connection
			conn.Open();
			//	Execute command
			cmd.ExecuteNonQuery();
			//	get return value
			int retValue = 0;
			try {
				//	get return value of the sproc
				retValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
			} catch(System.Exception) {	//	catch all possible exceptions
				retValue = 0;	//	set retValue To 0 (all ok)
			}
			//	close connection
			conn.Close();
			
			//	set dirty flag To false
			m_bIsDirty = false;
		
			return retValue;
		}
	
		//	operators
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator ==(Banners t1, Banners t2) {
			//	compare values
			if(t1.m_intBannerID != t2.m_intBannerID) {
				return false;	//	because "BannerID" values are Not equal
			}
	
			if(t1.m_intBannerPositionID != t2.m_intBannerPositionID) {
				return false;	//	because "BannerPositionID" values are Not equal
			}
	
			if(t1.m_intBannerFileTypeID != t2.m_intBannerFileTypeID) {
				return false;	//	because "BannerFileTypeID" values are Not equal
			}
	
			if(t1.m_intWidth != t2.m_intWidth) {
				return false;	//	because "Width" values are Not equal
			}
	
			if(t1.m_intHeight != t2.m_intHeight) {
				return false;	//	because "Height" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_intCreatedBy != t2.m_intCreatedBy) {
				return false;	//	because "CreatedBy" values are Not equal
			}
	
			if(t1.m_dtModifyDate != t2.m_dtModifyDate) {
				return false;	//	because "ModifyDate" values are Not equal
			}
	
			if(t1.m_intModifiedBy != t2.m_intModifiedBy) {
				return false;	//	because "ModifiedBy" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(Banners t1, Banners t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" BannerID = \"");
			retValue.Append(m_intBannerID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    BannerPositionID = \"");
			retValue.Append(m_intBannerPositionID);
			retValue.Append("\"\n");
				retValue.Append("    BannerFileTypeID = \"");
			retValue.Append(m_intBannerFileTypeID);
			retValue.Append("\"\n");
				retValue.Append("    Width = \"");
			retValue.Append(m_intWidth);
			retValue.Append("\"\n");
				retValue.Append("    Height = \"");
			retValue.Append(m_intHeight);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    CreatedBy = \"");
			retValue.Append(m_intCreatedBy);
			retValue.Append("\"\n");
				retValue.Append("    ModifyDate = \"");
			retValue.Append(m_dtModifyDate);
			retValue.Append("\"\n");
				retValue.Append("    ModifiedBy = \"");
			retValue.Append(m_intModifiedBy);
			retValue.Append("\"\n");
				return retValue.ToString();
		}
	
		/// <summary>
		/// Overrides the Equals Function.
		/// </summary>
		/// <param name="o">The Object To compare With</param>
		/// <returns>Bool if the two objects are identical.</returns>
		public override bool Equals(System.Object o) {
			//	check the type of o
			if (!(o is Banners)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (Banners)o;
		}
	
		/// <summary>
		/// Overrides the GetHashCode Function.
		/// </summary>
		/// <returns>Bool if the two objects are identical.</returns>
		public override int GetHashCode() {
			return this.ToString().GetHashCode();
		}
		
		
		
		
			
		/// <summary>
		/// The init Function.
		/// </summary>
		private void Init() {
			m_aAction = Action.Insert;	//	initial action  
			m_bIsDirty = false;	//	Objectstring"clean" upon init
		}
	}
}
