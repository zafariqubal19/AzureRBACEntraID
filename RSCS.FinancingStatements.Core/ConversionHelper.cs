using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities = RSCS.FinancingStatements.Core.Models.EntityModels;
using BusinessObjects = RSCS.FinancingStatements.Core.Models.BusinessObjects;


namespace RSCS.FinancingStatements.Core
{
    /// <summary>
    /// All of the Business Object to Entity Model Conversion should be done here
    /// </summary>
    /// 
    public static class BusinessObjectConversionHelper
	{
		public static Entities.tblSetting ToEntityModel(this Models.BusinessObjects.Setting.Setting setting, Entities.tblSetting existingSetting = null)
		{
            Entities.tblSetting convertedModel = existingSetting != null ? existingSetting : new Entities.tblSetting();
			convertedModel.Name = setting.Name;
			convertedModel.Value = setting.Value;
			return convertedModel;
		}

		public static Entities.tblUser ToEntityModel(this Models.BusinessObjects.User.User user, Entities.tblUser existingUser = null)
		{
			Entities.tblUser convertedModel = existingUser != null ? existingUser : new Entities.tblUser();
			convertedModel.NameID = user.NameID;
			convertedModel.ID = user.ID;
			convertedModel.FirstName = user.FirstName;
			convertedModel.MiddleName = user.MiddleName;
			convertedModel.LastName = user.LastName;
			convertedModel.Email = user.Email;
			return convertedModel;
		}
        public static Entities.tblFinPrograms ToEntityModel(this Models.BusinessObjects.FinPrograms.FinPrograms finPrograms, Entities.tblFinPrograms existingUser = null)
        {
            Entities.tblFinPrograms convertedModel = existingUser != null ? existingUser : new Entities.tblFinPrograms();
            convertedModel.ProgramID=finPrograms.ProgramID;
			convertedModel.CampaignCode = finPrograms.CampaignCode;
			convertedModel.Description=finPrograms.Description;
			convertedModel.StartDate = finPrograms.StartDate;
			convertedModel.EndDate = finPrograms.EndDate;
			convertedModel.PaymentTermsCode = finPrograms.PaymentTermsCode;
			convertedModel.DateAdded=finPrograms.DateAdded;
			convertedModel.ActiveProcess=finPrograms.ActiveProcess;
			convertedModel.ActiveWeb=finPrograms.ActiveWeb;
			convertedModel.Comments=finPrograms.Comments;
			convertedModel.FranchiseeCount=finPrograms.FranchiseeCount;
			convertedModel.InvoiceCount=finPrograms.InvoiceCount;
			convertedModel.StatementCount=finPrograms.StatementCount;
			convertedModel.StoreCount=finPrograms.StoreCount;
			convertedModel.StatementFranchiseeCount= finPrograms.StatementFranchiseeCount;
			convertedModel.LastStatementPeriod=finPrograms.LastStatementPeriod;
			convertedModel.FirstStatementPeriod=finPrograms.FirstStatementPeriod;
			convertedModel.FirstInvoice=finPrograms.FirstInvoice;
			convertedModel.lastInvoice = finPrograms.lastInvoice;






            return convertedModel;
        }
        public static Entities.tblFinProgramsFranchisee ToEntityModel(this Models.BusinessObjects.FinProgramsFranchisee.FinProgramsFranchisee finProgramsFranchisee, Entities.tblFinProgramsFranchisee existingUser = null)
        {
            Entities.tblFinProgramsFranchisee convertedModel = existingUser != null ? existingUser : new Entities.tblFinProgramsFranchisee();
            convertedModel.ProgramID = finProgramsFranchisee.ProgramID;
			convertedModel.MasterID=finProgramsFranchisee.MasterID;
			convertedModel.Reference=finProgramsFranchisee.Reference;
			convertedModel.InvoiceAmount=finProgramsFranchisee.InvoiceAmount;
			convertedModel.InvoiceStores=finProgramsFranchisee.InvoiceStores;
			convertedModel.Invoices=finProgramsFranchisee.Invoices;
			convertedModel.InvoiceDateFrom=finProgramsFranchisee.InvoiceDateFrom;
			convertedModel.InvoiceDateTo=finProgramsFranchisee.InvoiceDateTo;
			convertedModel.Statements=finProgramsFranchisee.Statements;
			convertedModel.StatementFrom=finProgramsFranchisee.StatementFrom;
			convertedModel.StatementTo=finProgramsFranchisee.StatementTo;
            return convertedModel;
        }
        public static Entities.tblInvoiceDetails ToEntityModel(this Models.BusinessObjects.InvoiceDetails.InvoiceDetails invoiceDetails, Entities.tblInvoiceDetails existingUser = null)
        {
            Entities.tblInvoiceDetails convertedModel = existingUser != null ? existingUser : new Entities.tblInvoiceDetails();
            convertedModel.InvoiceNo=invoiceDetails.InvoiceNo;
			convertedModel.InvoiceDate=invoiceDetails.InvoiceDate;
			convertedModel.TotalAmount=invoiceDetails.TotalAmount;
			convertedModel.ViewCount=invoiceDetails.ViewCount;
			convertedModel.BilltoCustomerNo=invoiceDetails.BilltoCustomerNo;
			convertedModel.BilltoName=invoiceDetails.BilltoName;
			convertedModel.SelltoCustomerNo=invoiceDetails.SelltoCustomerNo;
			convertedModel.StoreID=invoiceDetails.StoreID;
			convertedModel.SelltoCustomerName=invoiceDetails.SelltoCustomerName;
			convertedModel.SelltoAddress=invoiceDetails.SelltoAddress;
			convertedModel.SelltoCity=invoiceDetails.SelltoCity;
			convertedModel.SelltoState=invoiceDetails.SelltoState;
			convertedModel.SelltoZip=invoiceDetails.SelltoZip;
			convertedModel.OrigFilePath=invoiceDetails.OrigFilePath;
			convertedModel.FilePath=invoiceDetails.FilePath;
			convertedModel.DateAdded=invoiceDetails.DateAdded;
			convertedModel.Copied=invoiceDetails.Copied;
			convertedModel.ProgramID=invoiceDetails.ProgramID;
			convertedModel.masterID=invoiceDetails.masterID;
			convertedModel.FranchiseeID=invoiceDetails.FranchiseeID;
            return convertedModel;
        }
        public static Entities.tblStatementDetails ToEntityModel(this Models.BusinessObjects.StatementDetails.StatementDetails statementDetails, Entities.tblStatementDetails existingUser = null)
        {
            Entities.tblStatementDetails convertedModel = existingUser != null ? existingUser : new Entities.tblStatementDetails();
			convertedModel.Program=statementDetails.Program;
            convertedModel.Statement=statementDetails.Statement;
			convertedModel.FileName=statementDetails.FileName;
			convertedModel.FilePath=statementDetails.FilePath;
			convertedModel.DateAdded=statementDetails.DateAdded;
			convertedModel.QARoot=statementDetails.QARoot;
			convertedModel.ProdRoot=statementDetails.ProdRoot;
			convertedModel.StatementID=statementDetails.StatementID;
			convertedModel.ProgramID=statementDetails.ProgramID;
			convertedModel.FranchiseeID=statementDetails.FranchiseeID;
			convertedModel.MasterID=statementDetails.MasterID;
            return convertedModel;
        }
        public static Entities.tblReferences ToEntityModel(this Models.BusinessObjects.References.References references, Entities.tblReferences existingUser = null)
        {
            Entities.tblReferences convertedModel = existingUser != null ? existingUser : new Entities.tblReferences();
			convertedModel.MasterID = references.MasterId;
			convertedModel.Reference=references.Reference;
			convertedModel.Contacts=references.Contacts;
			convertedModel.AutoContacts=references.AutoContacts;
			convertedModel.AuthContacts=references.AuthContacts;

            return convertedModel;
        }
        public static Entities.tblContacts ToEntityModel(this Models.BusinessObjects.Contacts.Contacts contact, Entities.tblContacts existingUser = null)
        {
            Entities.tblContacts convertedModel = existingUser != null ? existingUser : new Entities.tblContacts();

            convertedModel.Status = contact.Status;
            convertedModel.FOR = contact.FOR;
            convertedModel.Contact = contact.Contact;
			convertedModel.Title = contact.Title;
            convertedModel.RT = contact.RT;
            convertedModel.A = contact.A;
            convertedModel.DateModified = contact.DateModified;
            convertedModel.CreateDate = contact.CreateDate;
            convertedModel.ModBy = contact.ModBy;
            convertedModel.EMail = contact.EMail;
            convertedModel.Phone = contact.Phone;
            convertedModel.NameID = contact.NameID;
            return convertedModel;
        }
        public static Entities.tblResourceSecurity ToEntityModel(this Models.BusinessObjects.ResourceSecurity.ResourceSecurity resourceSecurity, Entities.tblResourceSecurity existingUser = null)
        {
            Entities.tblResourceSecurity convertedModel = existingUser != null ? existingUser : new Entities.tblResourceSecurity();

            convertedModel.ResourceSecurityID = resourceSecurity.ResourceSecurityID;
			convertedModel.NameID= resourceSecurity.NameID;
			convertedModel.SystemID = resourceSecurity.SystemID;
			convertedModel.ResourceSecurityTypeID = resourceSecurity.ResourceSecurityTypeID;
			convertedModel.ResourceSecurityValue = resourceSecurity.ResourceSecurityValue;
			convertedModel.LastModified= resourceSecurity.LastModified;
			convertedModel.LastModifiedBy = resourceSecurity.LastModifiedBy;
			convertedModel.Comments = resourceSecurity.Comments;
			convertedModel.Active= resourceSecurity.Active;
            return convertedModel;
        }
    }

	/// <summary>
	/// All of the Entity Model to Business Object Model conversion should be done here
	/// </summary>
	///
	public static class EntityModelConversionHelper
	{
		public static Models.BusinessObjects.Setting.Setting ToBusinessObject(this Entities.tblSetting settingEntity)
		{
			return new BusinessObjects.Setting.Setting
			{
				ID = settingEntity.Id,
				Name = settingEntity.Name,
				Value = settingEntity.Value
			};
		}

		public static Models.BusinessObjects.User.User ToBusinessObject(this Entities.tblUser userEntity)
		{
			return new BusinessObjects.User.User
			{
				NameID = userEntity.NameID,
				ID = userEntity.ID,
				Email = userEntity.Email,
				FirstName = userEntity.FirstName,
				MiddleName = userEntity.MiddleName,
				LastName = userEntity.LastName,
				Permissions = new List<string>()
			};
		}
        public static Models.BusinessObjects.FinPrograms.FinPrograms ToBusinessObject(this Entities.tblFinPrograms finProgramsEntity)
        {
            return new BusinessObjects.FinPrograms.FinPrograms
            {
              ProgramID=finProgramsEntity.ProgramID,
			  CampaignCode=finProgramsEntity.CampaignCode,
			  Description=finProgramsEntity.Description,
			  StartDate=finProgramsEntity.StartDate,
			  EndDate=finProgramsEntity.EndDate,
			  PaymentTermsCode=finProgramsEntity.PaymentTermsCode,
			  DateAdded=finProgramsEntity.DateAdded,
                ActiveProcess = finProgramsEntity.ActiveProcess,
                ActiveWeb =finProgramsEntity.ActiveWeb,
				Comments = finProgramsEntity.Comments,
				FranchiseeCount=finProgramsEntity.FranchiseeCount,
				InvoiceCount=finProgramsEntity.InvoiceCount,
				StatementCount=finProgramsEntity.StatementCount,
				StoreCount=finProgramsEntity.StoreCount,
				StatementFranchiseeCount=finProgramsEntity.StatementFranchiseeCount,
				LastStatementPeriod=finProgramsEntity.LastStatementPeriod,
				FirstStatementPeriod=finProgramsEntity.FirstStatementPeriod,
				FirstInvoice=finProgramsEntity.FirstInvoice,
				lastInvoice=finProgramsEntity.lastInvoice,


            };
        }
        public static Models.BusinessObjects.FinProgramsFranchisee.FinProgramsFranchisee ToBusinessObject(this Entities.tblFinProgramsFranchisee finProgramsFranchiseeEntity)
        {
            return new BusinessObjects.FinProgramsFranchisee.FinProgramsFranchisee
            {
               Reference=finProgramsFranchiseeEntity.Reference,
			   InvoiceAmount=finProgramsFranchiseeEntity.InvoiceAmount,
			   InvoiceStores=finProgramsFranchiseeEntity.InvoiceStores,
			   Invoices=finProgramsFranchiseeEntity.Invoices,
			   InvoiceDateFrom=finProgramsFranchiseeEntity.InvoiceDateFrom,
			   InvoiceDateTo=finProgramsFranchiseeEntity.InvoiceDateTo,
			   Statements=finProgramsFranchiseeEntity.Statements,
			   StatementFrom=finProgramsFranchiseeEntity.StatementFrom,
			   StatementTo=finProgramsFranchiseeEntity.StatementTo,
			   MasterID=finProgramsFranchiseeEntity.MasterID,
			   ProgramID=finProgramsFranchiseeEntity.ProgramID,

            };
        }
        public static Models.BusinessObjects.InvoiceDetails.InvoiceDetails ToBusinessObject(this Entities.tblInvoiceDetails invoicDetailsEntity)
        {
            return new BusinessObjects.InvoiceDetails.InvoiceDetails
            {
                InvoiceNo=invoicDetailsEntity.InvoiceNo,
				InvoiceDate=invoicDetailsEntity.InvoiceDate,
				TotalAmount=invoicDetailsEntity.TotalAmount,
				ViewCount=invoicDetailsEntity.ViewCount,
				BilltoCustomerNo=invoicDetailsEntity.BilltoCustomerNo,
				BilltoName=invoicDetailsEntity.BilltoName,
				SelltoCustomerNo=invoicDetailsEntity.SelltoCustomerNo,
				StoreID=invoicDetailsEntity.StoreID,
				SelltoCustomerName=invoicDetailsEntity.SelltoCustomerName,
				SelltoAddress=invoicDetailsEntity.SelltoAddress,
				SelltoCity=invoicDetailsEntity.SelltoCity,
				SelltoState=invoicDetailsEntity.SelltoState,
				SelltoZip=invoicDetailsEntity.SelltoZip,	
				OrigFilePath=invoicDetailsEntity.OrigFilePath,
				FilePath=invoicDetailsEntity.FilePath,
				DateAdded=invoicDetailsEntity.DateAdded,
				Copied=invoicDetailsEntity.Copied,
				ProgramID=invoicDetailsEntity.ProgramID,
				masterID=invoicDetailsEntity.masterID,
				FranchiseeID=invoicDetailsEntity.FranchiseeID,

            };
        }
        public static Models.BusinessObjects.StatementDetails.StatementDetails ToBusinessObject(this Entities.tblStatementDetails statememtDetailsEntity)
        {
            return new BusinessObjects.StatementDetails.StatementDetails
            {
			Program=statememtDetailsEntity.Program,
			Statement=statememtDetailsEntity.Statement,
			FileName=statememtDetailsEntity.FileName,
			FilePath=statememtDetailsEntity.FilePath,
			DateAdded=statememtDetailsEntity.DateAdded,
			QARoot=statememtDetailsEntity.QARoot,
			ProdRoot=statememtDetailsEntity.ProdRoot,
			StatementID=statememtDetailsEntity.StatementID,
			ProgramID=statememtDetailsEntity.ProgramID,
			FranchiseeID=statememtDetailsEntity.FranchiseeID,
			MasterID=statememtDetailsEntity.MasterID,


            };
        }
        public static Models.BusinessObjects.References.References ToBusinessObject(this Entities.tblReferences referencesEntity)
        {
			return new BusinessObjects.References.References
			{
				MasterId = referencesEntity.MasterID,
				Reference=referencesEntity.Reference,
				Contacts=referencesEntity.Contacts,
				AuthContacts=referencesEntity.AuthContacts,
				AutoContacts=referencesEntity.AutoContacts,
            };
        }
        public static Models.BusinessObjects.Contacts.Contacts ToBusinessObject(this Entities.tblContacts contactsEntity)
        {
            return new BusinessObjects.Contacts.Contacts
            {

                Status = contactsEntity.Status,
                FOR = contactsEntity.FOR,
                Contact = contactsEntity.Contact,
				Title = contactsEntity.Title,
                RT = contactsEntity.RT,
                A = contactsEntity.A,
                DateModified = contactsEntity.DateModified,
                CreateDate = contactsEntity.CreateDate,
                ModBy = contactsEntity.ModBy,
                EMail = contactsEntity.EMail,
                Phone = contactsEntity.Phone,
                NameID = contactsEntity.NameID


            };
        }
        public static Models.BusinessObjects.ResourceSecurity.ResourceSecurity ToBusinessObject(this Entities.tblResourceSecurity resourceSecurityEntity)
        {
            return new BusinessObjects.ResourceSecurity.ResourceSecurity
            {

                ResourceSecurityID=resourceSecurityEntity.ResourceSecurityID,
				NameID=resourceSecurityEntity.NameID,
				SystemID=resourceSecurityEntity.SystemID,
				ResourceSecurityTypeID=resourceSecurityEntity.ResourceSecurityTypeID,
				ResourceSecurityValue=resourceSecurityEntity.ResourceSecurityValue,
				LastModified=resourceSecurityEntity.LastModified,
				LastModifiedBy=resourceSecurityEntity.LastModifiedBy,
				Comments= resourceSecurityEntity.Comments,
				Active=resourceSecurityEntity.Active,


            };
        }
    }
}
