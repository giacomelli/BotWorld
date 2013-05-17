﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Bot", "Bot", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DG.BotWorld.World.Model.Bot), "BotRanking", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DG.BotWorld.World.Model.BotRanking))]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Environment", "Environment", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DG.BotWorld.World.Model.Environment), "BotRanking", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DG.BotWorld.World.Model.BotRanking))]

// Original file name:
// Generation date: 04/10/2012 14:31:50
namespace DG.BotWorld.World.Model
{
    
    /// <summary>
    /// There are no comments for Entities in the schema.
    /// </summary>
    public partial class Entities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities() : 
                base("name=Entities", "Entities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string connectionString) : 
                base(connectionString, "Entities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "Entities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Bot in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<Bot> Bot
        {
            get
            {
                if ((this._Bot == null))
                {
                    this._Bot = base.CreateQuery<Bot>("[Bot]");
                }
                return this._Bot;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<Bot> _Bot;
        /// <summary>
        /// There are no comments for BotRanking in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<BotRanking> BotRanking
        {
            get
            {
                if ((this._BotRanking == null))
                {
                    this._BotRanking = base.CreateQuery<BotRanking>("[BotRanking]");
                }
                return this._BotRanking;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<BotRanking> _BotRanking;
        /// <summary>
        /// There are no comments for Environment in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<Environment> Environment
        {
            get
            {
                if ((this._Environment == null))
                {
                    this._Environment = base.CreateQuery<Environment>("[Environment]");
                }
                return this._Environment;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<Environment> _Environment;
        /// <summary>
        /// There are no comments for Bot in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToBot(Bot bot)
        {
            base.AddObject("Bot", bot);
        }
        /// <summary>
        /// There are no comments for BotRanking in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToBotRanking(BotRanking botRanking)
        {
            base.AddObject("BotRanking", botRanking);
        }
        /// <summary>
        /// There are no comments for Environment in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToEnvironment(Environment environment)
        {
            base.AddObject("Environment", environment);
        }
    }
    /// <summary>
    /// There are no comments for DG.BotWorld.World.Model.Bot in the schema.
    /// </summary>
    /// <KeyProperties>
    /// IdBot
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DG.BotWorld.World.Model", Name="Bot")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Bot : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Bot object.
        /// </summary>
        /// <param name="idBot">Initial value of IdBot.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static Bot CreateBot(int idBot, string name)
        {
            Bot bot = new Bot();
            bot.IdBot = idBot;
            bot.Name = name;
            return bot;
        }
        /// <summary>
        /// There are no comments for property IdBot in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int IdBot
        {
            get
            {
                return this._IdBot;
            }
            set
            {
                this.OnIdBotChanging(value);
                this.ReportPropertyChanging("IdBot");
                this._IdBot = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IdBot");
                this.OnIdBotChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _IdBot;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdBotChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdBotChanged();
        /// <summary>
        /// There are no comments for property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this.ReportPropertyChanging("Name");
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Name;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for BotRanking in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Bot", "BotRanking")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<BotRanking> BotRanking
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<BotRanking>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "BotRanking");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<BotRanking>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "BotRanking", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for DG.BotWorld.World.Model.BotRanking in the schema.
    /// </summary>
    /// <KeyProperties>
    /// IdBotRanking
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DG.BotWorld.World.Model", Name="BotRanking")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class BotRanking : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new BotRanking object.
        /// </summary>
        /// <param name="idBotRanking">Initial value of IdBotRanking.</param>
        /// <param name="score">Initial value of Score.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static BotRanking CreateBotRanking(int idBotRanking, float score)
        {
            BotRanking botRanking = new BotRanking();
            botRanking.IdBotRanking = idBotRanking;
            botRanking.Score = score;
            return botRanking;
        }
        /// <summary>
        /// There are no comments for property IdBotRanking in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int IdBotRanking
        {
            get
            {
                return this._IdBotRanking;
            }
            set
            {
                this.OnIdBotRankingChanging(value);
                this.ReportPropertyChanging("IdBotRanking");
                this._IdBotRanking = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IdBotRanking");
                this.OnIdBotRankingChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _IdBotRanking;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdBotRankingChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdBotRankingChanged();
        /// <summary>
        /// There are no comments for property Score in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public float Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                this.OnScoreChanging(value);
                this.ReportPropertyChanging("Score");
                this._Score = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Score");
                this.OnScoreChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private float _Score;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnScoreChanging(float value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnScoreChanged();
        /// <summary>
        /// There are no comments for Bot in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Bot", "Bot")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public Bot Bot
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Bot>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "Bot").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Bot>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "Bot").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for Bot in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<Bot> BotReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Bot>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "Bot");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<Bot>("DG.BotWorld.World.Model.FK_BotRanking_Bot", "Bot", value);
                }
            }
        }
        /// <summary>
        /// There are no comments for Environment in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Environment", "Environment")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public Environment Environment
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Environment>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "Environment").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Environment>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "Environment").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for Environment in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<Environment> EnvironmentReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Environment>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "Environment");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<Environment>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "Environment", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for DG.BotWorld.World.Model.Environment in the schema.
    /// </summary>
    /// <KeyProperties>
    /// IdEnvironment
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DG.BotWorld.World.Model", Name="Environment")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Environment : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Environment object.
        /// </summary>
        /// <param name="idEnvironment">Initial value of IdEnvironment.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static Environment CreateEnvironment(int idEnvironment, string name)
        {
            Environment environment = new Environment();
            environment.IdEnvironment = idEnvironment;
            environment.Name = name;
            return environment;
        }
        /// <summary>
        /// There are no comments for property IdEnvironment in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int IdEnvironment
        {
            get
            {
                return this._IdEnvironment;
            }
            set
            {
                this.OnIdEnvironmentChanging(value);
                this.ReportPropertyChanging("IdEnvironment");
                this._IdEnvironment = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IdEnvironment");
                this.OnIdEnvironmentChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _IdEnvironment;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdEnvironmentChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdEnvironmentChanged();
        /// <summary>
        /// There are no comments for property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this.ReportPropertyChanging("Name");
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Name;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for BotRanking in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("DG.BotWorld.World.Model", "FK_BotRanking_Environment", "BotRanking")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<BotRanking> BotRanking
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<BotRanking>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "BotRanking");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<BotRanking>("DG.BotWorld.World.Model.FK_BotRanking_Environment", "BotRanking", value);
                }
            }
        }
    }
}