/*
 * Aplikacja
 *
 * Społecznościowy system informowania o cenach paliw. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WebApplication2.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserChange : IEquatable<UserChange>
    { 
        /// <summary>
        /// Gets or Sets Login
        /// </summary>

        [DataMember(Name="Login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name="Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>

        [DataMember(Name="Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>

        [DataMember(Name="Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Passowrd
        /// </summary>

        [DataMember(Name="Passowrd")]
        public string Passowrd { get; set; }

        /// <summary>
        /// Klucz obcy do roli
        /// </summary>
        /// <value>Klucz obcy do roli</value>

        [DataMember(Name="Role")]
        public int? Role { get; set; }

        /// <summary>
        /// Gets or Sets Locaction
        /// </summary>

        [DataMember(Name="Locaction")]
        public string Locaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserChange {\n");
            sb.Append("  Login: ").Append(Login).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Passowrd: ").Append(Passowrd).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Locaction: ").Append(Locaction).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserChange)obj);
        }

        /// <summary>
        /// Returns true if UserChange instances are equal
        /// </summary>
        /// <param name="other">Instance of UserChange to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserChange other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Login == other.Login ||
                    Login != null &&
                    Login.Equals(other.Login)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Surname == other.Surname ||
                    Surname != null &&
                    Surname.Equals(other.Surname)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Passowrd == other.Passowrd ||
                    Passowrd != null &&
                    Passowrd.Equals(other.Passowrd)
                ) && 
                (
                    Role == other.Role ||
                    Role != null &&
                    Role.Equals(other.Role)
                ) && 
                (
                    Locaction == other.Locaction ||
                    Locaction != null &&
                    Locaction.Equals(other.Locaction)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Login != null)
                    hashCode = hashCode * 59 + Login.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Surname != null)
                    hashCode = hashCode * 59 + Surname.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Passowrd != null)
                    hashCode = hashCode * 59 + Passowrd.GetHashCode();
                    if (Role != null)
                    hashCode = hashCode * 59 + Role.GetHashCode();
                    if (Locaction != null)
                    hashCode = hashCode * 59 + Locaction.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserChange left, UserChange right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserChange left, UserChange right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
