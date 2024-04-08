using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TrainingFPTCo.Models;

namespace TrainingFPTCo.Models.Queries
{
    public class TopicQuery
    {
        public bool UpdateTopicById(
            int courseId,
            string name,
            string? description,
            string? status,
            string? documents,
            string? attachFiles,
            string? typeDocument,
            string? posterTopic,
            int id
        )
        {
            bool checkUpdate = false;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "UPDATE [Topics] SET [CourseId] = @CourseId, [Name] = @Name, [Description] = @Description, [Status] = @Status, [Documents] = @Documents, [AttachFiles] = @AttachFiles, [TypeDocument] = @TypeDocument, [PosterTopic] = @PosterTopic, [UpdatedAt] = @UpdatedAt WHERE [Id] = @Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Status", status ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Documents", documents ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@AttachFiles", attachFiles ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@TypeDocument", typeDocument ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@PosterTopic", posterTopic ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                checkUpdate = true;
                connection.Close();
            }
            return checkUpdate;
        }

        public bool DeleteTopicById(int id)
        {
            bool checkDelete = false;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sqlQuery = "UPDATE [Topics] SET [DeletedAt] = @DeletedAt WHERE [Id] = @Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@DeletedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                checkDelete = true;
                connection.Close();
            }
            return checkDelete;
        }

        public TopicDetail GetTopicDetailById(int id)
        {
            TopicDetail detail = new TopicDetail();
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "SELECT * FROM [Topics] WHERE [Id] = @Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detail.Id = Convert.ToInt32(reader["Id"]);
                        detail.CourseId = Convert.ToInt32(reader["CourseId"]);
                        detail.Name = reader["Name"].ToString();
                        detail.Description = reader["Description"].ToString();
                        detail.Status = reader["Status"].ToString();
                        detail.Documents = reader["Documents"].ToString();
                        detail.AttachFiles = reader["AttachFiles"].ToString();
                        detail.TypeDocument = reader["TypeDocument"].ToString();
                        detail.PosterTopic = reader["PosterTopic"].ToString();
                        detail.CreatedAt = reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : (DateTime?)null;
                        detail.UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedAt"]) : (DateTime?)null;
                        detail.DeletedAt = reader["DeletedAt"] != DBNull.Value ? Convert.ToDateTime(reader["DeletedAt"]) : (DateTime?)null;
                    }
                }
                connection.Close();
            }
            return detail;
        }

        public List<TopicDetail> GetAllTopics()
        {
            List<TopicDetail> topics = new List<TopicDetail>();
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sql = "SELECT * FROM [Topics]";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TopicDetail detail = new TopicDetail();
                        detail.Id = Convert.ToInt32(reader["Id"]);
                        detail.CourseId = Convert.ToInt32(reader["CourseId"]);
                        detail.Name = reader["Name"].ToString();
                        detail.Description = reader["Description"].ToString();
                        detail.Status = reader["Status"].ToString();
                        detail.Documents = reader["Documents"].ToString();
                        detail.AttachFiles = reader["AttachFiles"].ToString();
                        detail.TypeDocument = reader["TypeDocument"].ToString();
                        detail.PosterTopic = reader["PosterTopic"].ToString();
                        detail.CreatedAt = reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : (DateTime?)null;
                        detail.UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedAt"]) : (DateTime?)null;
                        detail.DeletedAt = reader["DeletedAt"] != DBNull.Value ? Convert.ToDateTime(reader["DeletedAt"]) : (DateTime?)null;
                        topics.Add(detail);
                    }
                }
                connection.Close();
            }
            return topics;
        }

        public int InsertTopic(
            int courseId,
            string name,
            string? description,
            string? status,
            string? documents,
            string? attachFiles,
            string? typeDocument,
            string? posterTopic
        )
        {
            int topicId = 0;
            using (SqlConnection connection = Database.GetSqlConnection())
            {
                string sqlQuery = "INSERT INTO [Topics]([CourseId], [Name], [Description], [Status], [Documents], [AttachFiles], [TypeDocument], [PosterTopic], [CreatedAt]) VALUES(@CourseId, @Name, @Description, @Status, @Documents, @AttachFiles, @TypeDocument, @PosterTopic, @CreatedAt) SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Status", status ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Documents", documents ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@AttachFiles", attachFiles ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@TypeDocument", typeDocument ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@PosterTopic", posterTopic ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                topicId = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return topicId;
        }
    }
}
