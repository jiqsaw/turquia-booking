using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace HOTOMOTO.APEX {

	public class RoomComments {
	
		
		//	members
				private Action m_aAction;
		
		private bool m_bIsDirty;
		
		//	members from table
		private SqlInt32 m_intRoomRatingID;
		private SqlInt32 m_intRoomID;
		private SqlInt32 m_intCustomerID;
		private SqlInt32 m_intLanguageID;
		private SqlString m_strOriginalComment;
		private SqlString m_strApprovedComment;
		private SqlInt32 m_intRating;
		private SqlDateTime m_dtCreateDate;
		private SqlBoolean m_bolisConfirmed;
		private SqlDateTime m_dtConfirmationDate;
		private SqlInt32 m_intConfirmedBy;
		private SqlBoolean m_bolisActive;
	private SqlTransaction m_Transaction;
	
	
	/// <summary>
		/// Default constructor.
		/// </summary>
		public RoomComments() {
			Init();	//	init Object	

		}
		
	
		/// <summary>
		/// Gets all RoomComments from the database, using the default connection string, into a SQLDataReader
		/// </summary>
		/// <returns>The SQLDataReader With the RoomComments</returns>
		public static SqlDataReader GetAllRoomCommentsReader() {
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomComments__sel_all", conn);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		
		public static DataSet GetAllRoomCommentsDataSet() {
            SqlConnection conn = DBHelper.getConnection();
            SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomComments__sel_all", conn);


            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
		
		/// <summary>
		/// Gets all RoomComments from the database, using the default connection string, into a hashtable SQLReader
		/// </summary>
		/// <returns></returns>
		public static Hashtable GetAllRoomComments() {
			SqlDataReader dr = GetAllRoomCommentsReader();
			return ConvertReaderToHashTable(dr);
		}
		
		/// <summary>
		/// Creates RoomComments for records In the prefilled DataReader, And puts them into a HashTable
		/// </summary>
		/// <param name="dr">The DataReader prefilled With the RoomComments records</param>
		/// <returns>The Hashtable containing RoomComments objects And their ID As key.</returns>
		private static Hashtable ConvertReaderToHashTable(SqlDataReader dr) {
			Hashtable result = new Hashtable();
			while (dr.Read()) {
	            RoomComments myRoomComments = new RoomComments();
            
            myRoomComments.m_intRoomRatingID = dr.GetSqlInt32(0);
            myRoomComments.m_intRoomID = dr.GetSqlInt32(1);
            myRoomComments.m_intCustomerID = dr.GetSqlInt32(2);
            myRoomComments.m_intLanguageID = dr.GetSqlInt32(3);
            myRoomComments.m_strOriginalComment = dr.GetSqlString(4);
            myRoomComments.m_strApprovedComment = dr.GetSqlString(5);
            myRoomComments.m_intRating = dr.GetSqlInt32(6);
            myRoomComments.m_dtCreateDate = dr.GetSqlDateTime(7);
            myRoomComments.m_bolisConfirmed = dr.GetSqlBoolean(8);
            myRoomComments.m_dtConfirmationDate = dr.GetSqlDateTime(9);
            myRoomComments.m_intConfirmedBy = dr.GetSqlInt32(10);
            myRoomComments.m_bolisActive = dr.GetSqlBoolean(11);
            
            result.Add(myRoomComments.RoomRatingID, myRoomComments);
		}
	
			return result;
		}
		
		
		//	enum types
		enum Action { Insert, Update, Delete };
		
			
		//	Sub-types
		public struct PK {
			public SqlInt32 RoomRatingID;
	}	
		/// <summary>
		/// The primary key column In the DB
		/// </summary>
		public PK PrimaryKey {
			get {
				PK pk;
				pk.RoomRatingID = m_intRoomRatingID;
				return pk;
			}
		}
			/// <summary>
		/// The RoomRatingID column in the DB
		/// </summary>
		public int RoomRatingID {
			get {
				return (int)m_intRoomRatingID;
			}
			set {
				m_intRoomRatingID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The RoomID column in the DB
		/// </summary>
		public int RoomID {
			get {
				return (int)m_intRoomID;
			}
			set {
				m_intRoomID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The CustomerID column in the DB
		/// </summary>
		public int CustomerID {
			get {
				return (int)m_intCustomerID;
			}
			set {
				m_intCustomerID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The LanguageID column in the DB
		/// </summary>
		public int LanguageID {
			get {
				return (int)m_intLanguageID;
			}
			set {
				m_intLanguageID = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The OriginalComment column in the DB
		/// </summary>
		public string OriginalComment {
			get {
				return (string)m_strOriginalComment;
			}
			set {
				m_strOriginalComment = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ApprovedComment column in the DB
		/// </summary>
		public string ApprovedComment {
			get {
				return (string)m_strApprovedComment;
			}
			set {
				m_strApprovedComment = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The Rating column in the DB
		/// </summary>
		public int Rating {
			get {
				return (int)m_intRating;
			}
			set {
				m_intRating = value;
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
		/// The isConfirmed column in the DB
		/// </summary>
		public bool isConfirmed {
			get {
				return (bool)m_bolisConfirmed;
			}
			set {
				m_bolisConfirmed = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ConfirmationDate column in the DB
		/// </summary>
		public DateTime ConfirmationDate {
			get {
				return (DateTime)m_dtConfirmationDate;
			}
			set {
				m_dtConfirmationDate = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The ConfirmedBy column in the DB
		/// </summary>
		public int ConfirmedBy {
			get {
				return (int)m_intConfirmedBy;
			}
			set {
				m_intConfirmedBy = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// The isActive column in the DB
		/// </summary>
		public bool isActive {
			get {
				return (bool)m_bolisActive;
			}
			set {
				m_bolisActive = value;
				m_bIsDirty = true;
			}
		}
			/// <summary>
		/// Fills the member variables of the Object from the DB based On the primary key, returns true if success.
		/// </summary>
		/// <param name="pk">PK struct</param>
		/// <returns>true member variables filled.</returns>
		public bool Load(PK pk) {
			return Load(pk.RoomRatingID.Value);		}
	
		/// <summary>
		/// Fills the member variables of the Object from the DB based on the primary key, returns true if success.
		/// </summary>
		/// <param name="intRoomRatingID"> RoomRatingID key value</param>
	/// <returns>true if success</returns>
		public bool Load(Int32 intRoomRatingID) {	
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			SqlCommand cmd = DBHelper.getSprocCmd("proc_RoomComments__sel", conn);
		
			SqlParameter param;
		
				//	Add params
	        // parameter for RoomRatingID column
        param = new SqlParameter("@RoomRatingID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = intRoomRatingID;
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
		            m_intRoomRatingID = reader.GetSqlInt32(0);
            m_intRoomID = reader.GetSqlInt32(1);
            m_intCustomerID = reader.GetSqlInt32(2);
            m_intLanguageID = reader.GetSqlInt32(3);
            m_strOriginalComment = reader.GetSqlString(4);
            m_strApprovedComment = reader.GetSqlString(5);
            m_intRating = reader.GetSqlInt32(6);
            m_dtCreateDate = reader.GetSqlDateTime(7);
            m_bolisConfirmed = reader.GetSqlBoolean(8);
            m_dtConfirmationDate = reader.GetSqlDateTime(9);
            m_intConfirmedBy = reader.GetSqlInt32(10);
            m_bolisActive = reader.GetSqlBoolean(11);
		
			} else {
					//	set key values
		            m_intRoomRatingID = intRoomRatingID;
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
							cmd = DBHelper.getSprocCmd("proc_RoomComments__ins", conn, this.m_Transaction);
			} else {
							cmd = DBHelper.getSprocCmd("proc_RoomComments__ins", conn);
			}
			
			SqlParameter param;
		
			//	Add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomRatingID column
        param = new SqlParameter("@RoomRatingID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomRatingID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for OriginalComment column
        param = new SqlParameter("@OriginalComment", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strOriginalComment;
        cmd.Parameters.Add(param);
        
        // parameter for ApprovedComment column
        param = new SqlParameter("@ApprovedComment", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strApprovedComment;
        cmd.Parameters.Add(param);
        
        // parameter for Rating column
        param = new SqlParameter("@Rating", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRating;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for isConfirmed column
        param = new SqlParameter("@isConfirmed", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisConfirmed;
        cmd.Parameters.Add(param);
        
        // parameter for ConfirmationDate column
        param = new SqlParameter("@ConfirmationDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtConfirmationDate;
        cmd.Parameters.Add(param);
        
        // parameter for ConfirmedBy column
        param = new SqlParameter("@ConfirmedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intConfirmedBy;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
	
		/// <summary>
		/// Updates the Object To the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int upd() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_RoomComments__upd", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomComments__upd", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	add params
		        // parameter for RoomRatingID column
        param = new SqlParameter("@RoomRatingID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomRatingID;
        cmd.Parameters.Add(param);
        
        // parameter for RoomID column
        param = new SqlParameter("@RoomID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomID;
        cmd.Parameters.Add(param);
        
        // parameter for CustomerID column
        param = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intCustomerID;
        cmd.Parameters.Add(param);
        
        // parameter for LanguageID column
        param = new SqlParameter("@LanguageID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intLanguageID;
        cmd.Parameters.Add(param);
        
        // parameter for OriginalComment column
        param = new SqlParameter("@OriginalComment", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strOriginalComment;
        cmd.Parameters.Add(param);
        
        // parameter for ApprovedComment column
        param = new SqlParameter("@ApprovedComment", SqlDbType.NVarChar, 1024);
        param.Direction = ParameterDirection.Input;
        param.Value = m_strApprovedComment;
        cmd.Parameters.Add(param);
        
        // parameter for Rating column
        param = new SqlParameter("@Rating", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRating;
        cmd.Parameters.Add(param);
        
        // parameter for CreateDate column
        param = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtCreateDate;
        cmd.Parameters.Add(param);
        
        // parameter for isConfirmed column
        param = new SqlParameter("@isConfirmed", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisConfirmed;
        cmd.Parameters.Add(param);
        
        // parameter for ConfirmationDate column
        param = new SqlParameter("@ConfirmationDate", SqlDbType.DateTime, 8);
        param.Direction = ParameterDirection.Input;
        param.Value = m_dtConfirmationDate;
        cmd.Parameters.Add(param);
        
        // parameter for ConfirmedBy column
        param = new SqlParameter("@ConfirmedBy", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intConfirmedBy;
        cmd.Parameters.Add(param);
        
        // parameter for isActive column
        param = new SqlParameter("@isActive", SqlDbType.Bit, 1);
        param.Direction = ParameterDirection.Input;
        param.Value = m_bolisActive;
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
	
		/// <summary>
		/// Deletes the Object from the DB.
		/// </summary>
		/// <returns>0 if success</returns>
		private int del() {
			//	construct new connection and command objects
			SqlConnection conn = DBHelper.getConnection();
			
			SqlCommand cmd;
			if(this.m_Transaction != null) {
				cmd = DBHelper.getSprocCmd("proc_RoomComments__del", conn, this.m_Transaction);
			} else {
				cmd = DBHelper.getSprocCmd("proc_RoomComments__del", conn);
			}
		
			SqlParameter param;
		
			//	add return value param
			param = new SqlParameter("@RETURN_VALUE",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);
		
			//	Add params
		        // parameter for RoomRatingID column
        param = new SqlParameter("@RoomRatingID", SqlDbType.Int, 4);
        param.Direction = ParameterDirection.Input;
        param.Value = m_intRoomRatingID;
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
		public static bool operator ==(RoomComments t1, RoomComments t2) {
			//	compare values
			if(t1.m_intRoomRatingID != t2.m_intRoomRatingID) {
				return false;	//	because "RoomRatingID" values are Not equal
			}
	
			if(t1.m_intRoomID != t2.m_intRoomID) {
				return false;	//	because "RoomID" values are Not equal
			}
	
			if(t1.m_intCustomerID != t2.m_intCustomerID) {
				return false;	//	because "CustomerID" values are Not equal
			}
	
			if(t1.m_intLanguageID != t2.m_intLanguageID) {
				return false;	//	because "LanguageID" values are Not equal
			}
	
			if(t1.m_strOriginalComment != t2.m_strOriginalComment) {
				return false;	//	because "OriginalComment" values are Not equal
			}
	
			if(t1.m_strApprovedComment != t2.m_strApprovedComment) {
				return false;	//	because "ApprovedComment" values are Not equal
			}
	
			if(t1.m_intRating != t2.m_intRating) {
				return false;	//	because "Rating" values are Not equal
			}
	
			if(t1.m_dtCreateDate != t2.m_dtCreateDate) {
				return false;	//	because "CreateDate" values are Not equal
			}
	
			if(t1.m_bolisConfirmed != t2.m_bolisConfirmed) {
				return false;	//	because "isConfirmed" values are Not equal
			}
	
			if(t1.m_dtConfirmationDate != t2.m_dtConfirmationDate) {
				return false;	//	because "ConfirmationDate" values are Not equal
			}
	
			if(t1.m_intConfirmedBy != t2.m_intConfirmedBy) {
				return false;	//	because "ConfirmedBy" values are Not equal
			}
	
			if(t1.m_bolisActive != t2.m_bolisActive) {
				return false;	//	because "isActive" values are Not equal
			}
	
			return true;	//	because every Valuestringequal
		}
	
		/// <summary>
		/// Compares two objects
		/// </summary>
		/// <param name="t1">The first Object To compare</param>
		/// <param name="t2">The Second Object To compare</param>
		/// <returns>true if success</returns>
		public static bool operator !=(RoomComments t1, RoomComments t2) {
			return !(t1 == t2);
		}
	
		//	Object methods
		
		/// <summary>
		/// Overrides the ToString Function.
		/// </summary>
		/// <returns>The string representation of the Object</returns>
		public override string ToString() {
			System.Text.StringBuilder retValue = new System.Text.StringBuilder("Keys:\n");		
				retValue.Append(" RoomRatingID = \"");
			retValue.Append(m_intRoomRatingID);
			retValue.Append("\"\n");
			
			retValue.Append("Columns:\n");
				retValue.Append("    RoomID = \"");
			retValue.Append(m_intRoomID);
			retValue.Append("\"\n");
				retValue.Append("    CustomerID = \"");
			retValue.Append(m_intCustomerID);
			retValue.Append("\"\n");
				retValue.Append("    LanguageID = \"");
			retValue.Append(m_intLanguageID);
			retValue.Append("\"\n");
				retValue.Append("    OriginalComment = \"");
			retValue.Append(m_strOriginalComment);
			retValue.Append("\"\n");
				retValue.Append("    ApprovedComment = \"");
			retValue.Append(m_strApprovedComment);
			retValue.Append("\"\n");
				retValue.Append("    Rating = \"");
			retValue.Append(m_intRating);
			retValue.Append("\"\n");
				retValue.Append("    CreateDate = \"");
			retValue.Append(m_dtCreateDate);
			retValue.Append("\"\n");
				retValue.Append("    isConfirmed = \"");
			retValue.Append(m_bolisConfirmed);
			retValue.Append("\"\n");
				retValue.Append("    ConfirmationDate = \"");
			retValue.Append(m_dtConfirmationDate);
			retValue.Append("\"\n");
				retValue.Append("    ConfirmedBy = \"");
			retValue.Append(m_intConfirmedBy);
			retValue.Append("\"\n");
				retValue.Append("    isActive = \"");
			retValue.Append(m_bolisActive);
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
			if (!(o is RoomComments)) {
				//	types Not the same, return false
				return false;
			}
	
			//	compare objects And return retValue
			return this == (RoomComments)o;
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
