/* 
 * Flipdish Open API v1.0
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Flipdish.Recruiting.WebhookReceiver.DAL.Models
{
    /// <summary>
    /// Fee Summary
    /// </summary>
    [DataContract]
    public partial class FeeSummary :  IEquatable<FeeSummary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeeSummary" /> class.
        /// </summary>
        /// <param name="feeAmount">Fee amount.</param>
        /// <param name="percentageRate">Percentage rate.</param>
        /// <param name="perTransactionFee">Per transaction fee.</param>
        public FeeSummary(double? feeAmount = default(double?), double? percentageRate = default(double?), double? perTransactionFee = default(double?))
        {
            this.FeeAmount = feeAmount;
            this.PercentageRate = percentageRate;
            this.PerTransactionFee = perTransactionFee;
        }
        
        /// <summary>
        /// Fee amount
        /// </summary>
        /// <value>Fee amount</value>
        [DataMember(Name="FeeAmount", EmitDefaultValue=false)]
        public double? FeeAmount { get; set; }

        /// <summary>
        /// Percentage rate
        /// </summary>
        /// <value>Percentage rate</value>
        [DataMember(Name="PercentageRate", EmitDefaultValue=false)]
        public double? PercentageRate { get; set; }

        /// <summary>
        /// Per transaction fee
        /// </summary>
        /// <value>Per transaction fee</value>
        [DataMember(Name="PerTransactionFee", EmitDefaultValue=false)]
        public double? PerTransactionFee { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FeeSummary {\n");
            sb.Append("  FeeAmount: ").Append(FeeAmount).Append("\n");
            sb.Append("  PercentageRate: ").Append(PercentageRate).Append("\n");
            sb.Append("  PerTransactionFee: ").Append(PerTransactionFee).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as FeeSummary);
        }

        /// <summary>
        /// Returns true if FeeSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of FeeSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FeeSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FeeAmount == input.FeeAmount ||
                    (this.FeeAmount != null &&
                    this.FeeAmount.Equals(input.FeeAmount))
                ) && 
                (
                    this.PercentageRate == input.PercentageRate ||
                    (this.PercentageRate != null &&
                    this.PercentageRate.Equals(input.PercentageRate))
                ) && 
                (
                    this.PerTransactionFee == input.PerTransactionFee ||
                    (this.PerTransactionFee != null &&
                    this.PerTransactionFee.Equals(input.PerTransactionFee))
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
                int hashCode = 41;
                if (this.FeeAmount != null)
                    hashCode = hashCode * 59 + this.FeeAmount.GetHashCode();
                if (this.PercentageRate != null)
                    hashCode = hashCode * 59 + this.PercentageRate.GetHashCode();
                if (this.PerTransactionFee != null)
                    hashCode = hashCode * 59 + this.PerTransactionFee.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
