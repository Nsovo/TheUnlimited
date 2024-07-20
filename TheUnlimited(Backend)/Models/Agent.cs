using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheUnlimited_Backend_.Models
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public int AgentLevelID { get; set; }
        public DateTime AgentStartDate { get; set; }
        public int AgentStatusID { get; set; }
        public DateTime? AgentTerminationDate { get; set; }
        public int? OfficeCode { get; set; }
        public string? MerchCode { get; set; }
        public string? UplineName { get; set; }
        public string? UplineMerchCode { get; set; }
        public int? ScheduleID { get; set; }
        public int SalesChannelID { get; set; }
        [ForeignKey("Upline")]
        public int ? UplineID { get; set; }

        public User User { get; set; }
        public AgentLevel AgentLevel { get; set; }
        public AgentStatus AgentStatus { get; set; }
        public Office Office { get; set; }
        public Schedule Schedule { get; set; }
        public SalesChannel SalesChannel { get; set; }
        public ICollection<Commission> Commissions { get; set; }
        public ICollection<Reward> Rewards { get; set; }
        public ICollection<ProductSales> ProductSales { get; set; }
        public ICollection<Query> Queries { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }
        public  virtual Agent Upline { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
       
        public ICollection<User> Users { get; set; }
        public ICollection<Hierarchy> Hierarchies { get; set; }
    }
}