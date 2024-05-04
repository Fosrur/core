using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Reflection;
using Newtonsoft.Json;
using core.Models;
using System.Data;


namespace core.DataModels
{
	/// <summary>
	/// Definition of BaseModel
	/// </summary>
	public class BaseModel
	{
		/// <summary>
		/// Definition of connexString
		/// </summary>
		private string connexString;

		/// <summary>
		/// Definition of UserEmail
		/// </summary>
		public string? UserEmail { get; set; }


        /// <summary>
        /// Definition of SatrtDate
        /// </summary>
        public string? StartDate { get; set; }

        /// <summary>
        /// Definition of SatrtDate
        /// </summary>
        public string? EndDate { get; set; }

        /// <summary>
        /// Definition of ReturnDataSet
        /// </summary>
        public DataSet ReturnDataSet { get; set; }

		/// <summary>
		/// Definition of ProcedureName
		/// </summary>
		public string? ProcedureName { get; set; }

		/// <summary>
		/// Definition of BaseModel
		/// </summary>
		public BaseModel(IOptions<SQLConfig> settings)
		{

			connexString = settings.Value.ToString();
			ReturnDataSet = new DataSet();
			ProcedureName = string.Empty;
			UserEmail = string.Empty;
			StartDate = string.Empty;
            EndDate = string.Empty;
        }

		/// <summary>
		/// Definition of SerializeResponse
		/// </summary>
		public virtual string SerializeResponse() => JsonConvert.SerializeObject(new { esito = "OK", item = ReturnDataSet });

		/// <summary>
		/// Definition of SerializeResponse
		/// </summary>
		/// <param name="returnObject"></param>
		public virtual string SerializeResponse(object returnObject) => JsonConvert.SerializeObject(new { esito = "OK", item = returnObject });

		/// <summary>
		/// Definition of SerializeErrorResponse
		/// </summary>
		public virtual string SerializeErrorResponse(Exception ex) => JsonConvert.SerializeObject(new { esito = "KO", item = new { error = ex.Message } });

		/// <summary>
		/// Returns DataTable from List<typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="table"></param>
		/// <returns></returns>
		public static List<T> TableToList<T>(DataTable table)
		{
			List<T> list = new();
			foreach (DataRow rw in table.Rows)
			{
				T item = Activator.CreateInstance<T>();
				foreach (DataColumn cl in table.Columns)
				{
					PropertyInfo? pi = typeof(T).GetProperty(cl.ColumnName);

					if (pi != null && rw[cl] != DBNull.Value)
					{
						var propType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
						pi.SetValue(item, Convert.ChangeType(rw[cl], propType), new object[0]);
					}

				}
				list.Add(item);
			}
			return list;
		}

		/// <summary>
		/// Definition of SELECT statement
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public bool Select()
		{
			try
			{
				ReturnDataSet = new DataSet();

				using SqlConnection sqlConnection = new(connexString);
				sqlConnection.Open();
				SqlTransaction transaction = sqlConnection.BeginTransaction();
				SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
				{
					CommandType = CommandType.StoredProcedure,
					Transaction = transaction
				};

				sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

				transaction.Commit();

				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of SELECT statement
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public bool Select(object inputData)
		{
			try
			{
				ReturnDataSet = new DataSet();

				using SqlConnection sqlConnection = new(connexString);

				sqlConnection.Open();

				//aggiungere gestione transazione

				SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
				{
					CommandType = CommandType.StoredProcedure,
				};

				sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter = sqlCommand.Parameters.AddWithValue("@DATASET", inputData);
				dataTableParameter.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

        /// <summary>
        /// Definition of SELECT statement
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool SelectByFilter(object inputData)
        {
            try
            {
                ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);

                sqlConnection.Open();

                //aggiungere gestione transazione

                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@START_DATE", (object)StartDate! ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@END_DATE", (object)EndDate! ?? DBNull.Value);
                SqlParameter dataTableParameter = sqlCommand.Parameters.AddWithValue("@DATASET", inputData);
                dataTableParameter.SqlDbType = SqlDbType.Structured;

                SqlDataAdapter sqlDataAdapter = new()
                {
                    SelectCommand = sqlCommand
                };

                sqlDataAdapter.Fill(ReturnDataSet);

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        /// <summary>
        /// Definition of SELECT statement
        /// </summary>
        /// <param name="inputData1"></param>
        /// <param name="inputData2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Select(object inputData1, object inputData2)
		{
			try
			{
				ReturnDataSet = new DataSet();

				using SqlConnection sqlConnection = new(connexString);

				sqlConnection.Open();

				//aggiungere gestione transazione

				SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
				{
					CommandType = CommandType.StoredProcedure,
				};

				sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter1 = sqlCommand.Parameters.AddWithValue("@DATASET1", inputData1);
				dataTableParameter1.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter2 = sqlCommand.Parameters.AddWithValue("@DATASET2", inputData2);
				dataTableParameter2.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

				sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of INSERT statement
		/// </summary>
		public bool Insert(object inputData)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter = sqlCommand.Parameters.AddWithValue("@DATASET", inputData);
				dataTableParameter.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of INSERT statement
		/// </summary>
		public bool Insert(object inputData1, object inputData2)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter1 = sqlCommand.Parameters.AddWithValue("@DATASET1", inputData1);
				dataTableParameter1.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter2 = sqlCommand.Parameters.AddWithValue("@DATASET2", inputData2);
				dataTableParameter2.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of INSERT statement
		/// </summary>
		public bool Insert(object inputData1, object inputData2, object inputData3)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter1 = sqlCommand.Parameters.AddWithValue("@DATASET1", inputData1);
				dataTableParameter1.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter2 = sqlCommand.Parameters.AddWithValue("@DATASET2", inputData2);
				dataTableParameter2.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter3 = sqlCommand.Parameters.AddWithValue("@DATASET3", inputData3);
				dataTableParameter3.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of UPDATE statement
		/// </summary>
		public bool Update(object inputData)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter = sqlCommand.Parameters.AddWithValue("@DATASET", inputData);
				dataTableParameter.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of UPDATE statement
		/// </summary>
		public bool Update(object inputData1, object inputData2)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter1 = sqlCommand.Parameters.AddWithValue("@DATASET1", inputData1);
				dataTableParameter1.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter2 = sqlCommand.Parameters.AddWithValue("@DATASET2", inputData2);
				dataTableParameter2.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of UPDATE statement
		/// </summary>
		public bool Update(object inputData1, object inputData2, object inputData3)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter1 = sqlCommand.Parameters.AddWithValue("@DATASET1", inputData1);
				dataTableParameter1.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter2 = sqlCommand.Parameters.AddWithValue("@DATASET2", inputData2);
				dataTableParameter2.SqlDbType = SqlDbType.Structured;
				SqlParameter dataTableParameter3 = sqlCommand.Parameters.AddWithValue("@DATASET3", inputData3);
				dataTableParameter3.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}

		/// <summary>
		/// Definition of DELETE statement
		/// </summary>
		public bool Delete(object inputData)
		{
			try
			{
				ReturnDataSet = new DataSet();

                using SqlConnection sqlConnection = new(connexString);
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new(ProcedureName, sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaction
                };

                sqlCommand.Parameters.AddWithValue("@MAIL_UTENTE", (object)UserEmail! ?? DBNull.Value);
				SqlParameter dataTableParameter = sqlCommand.Parameters.AddWithValue("@DATASET", inputData);
				dataTableParameter.SqlDbType = SqlDbType.Structured;

				SqlDataAdapter sqlDataAdapter = new()
				{
					SelectCommand = sqlCommand
				};

				sqlDataAdapter.Fill(ReturnDataSet);

                transaction.Commit();

                sqlConnection.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return true;
		}
	}
}
