using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E2aForums
{
    public static class CConstants
    {
        public enum enmRegistrationType
        {
            Facebook = 1,
            Gmail = 2,
            LinkedIn = 3,
            Default = 4,
            Univ = 5
        }

        public enum enmUserType
        {
            Experts = 1,
            Users = 2,
            Advisors = 3          
        }

        public enum enumJobStatus
        {
            JobAdded = 1,
            JobAcceptedByAny = 2,
            JobEmployed = 3,
            JobCompleted = 4,
            JobCancelled = 5,
            WorkerArrivedForJob = 6,

        }

        public enum enumTables
        {
            TblUsers,
            TblSkillsTypes,
            TblSkillsAndEquipments,
            TblSkillSupplies,
            TblSkillQuestions,
            TblSkillQuestAnsOptions,
            TblGetEmployerCount,
            TblGetWorkerCount,
            TblJobs,
            TblCustomerJobsCount,
            TblWorkerJobsCount,
            TblCategories,
            TblTopics,
            TblTopicList,
            TblAdvertisements,
            TblAdvertisementZone,
            TblExperts,
            TblChapters,
            TblSubTitles,
            TblCustomers,
            TblDocs,
            TblProducts
        }
       
    }
}