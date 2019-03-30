using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCAT.DBLayer
{
    public class DBAccesslayer
    {

        public static void  AddUser(vts_tbuser _user)
        {
            using (OCAT model = new OCAT())
            {
                model.Users.Add(_user);
                model.SaveChanges();
            }
        }

        public static void AddOrUpdate(DataModel record)
        {
            vts_tbvoter voter = new vts_tbvoter();
            vts_tbvoterdetail voterdetail = new vts_tbvoterdetail();
            vts_tbvotereducation voterEdu = new vts_tbvotereducation();
            vts_tbvoteranswers voterAns = new vts_tbvoteranswers();


            if (record != null)
            {
                voterdetail.firstname = record.firstname;
                voterdetail.middle = record.middle;
                voterdetail.lastname = record.lastname;
                voterdetail.email = record.email;
                voterdetail.age = record.age;
                voterdetail.customerid = record.customerid;
                voterdetail.ssn = record.ssn;
                voterdetail.gender = record.gender;
                voterdetail.dob = record.dob;

                voter.uid = record.uid;
                voter.surveyid = record.surveyid;
                voter.contextusername = record.contextusername;
                voter.votedate = record.votedate;
                voter.startdate = record.startdate;
                voter.ipsource = record.ipsource;
                voter.validated = record.validated;
                voter.resumeuid = record.resumeuid;
                voter.resumeatpagenumber = record.resumeatpagenumber;
                voter.progresssavedate = record.progresssavedate;
                voter.resumequestionnumber = record.resumequestionnumber;
                voter.resumehighestpagenumber = record.resumehighestpagenumber;
                voter.languagecode = record.languagecode;

                voterEdu.graduate = record.graduate;
                voterEdu.graduateyear = record.graduateyear;
                voterEdu.postgraduate = record.postgraduate;
                voterEdu.pgyear = record.pgyear;
                voterEdu.highdegree = record.highdegree;
                voterEdu.other = record.other;

                voterAns.sectionnumber = record.sectionnumber;
                voterAns.noshow = record.noshow;
                voterAns.answertext = record.answertext;
            }

           

            using (OCAT model = new OCAT())
            {
                model.Database.CommandTimeout = 240;

                //int voterfound = (from v in model.VoterDetails
                //                  where v.firstname == voterdetail.firstname && v.lastname == voterdetail.lastname
                //                  select v.voterid).FirstOrDefault();

                int voterfound = (from v in model.Voters
                                  where v.uid == voter.uid 
                                  select v.voterid).FirstOrDefault();

                if (voterfound==0)
                {
                    //add record 
                    model.Voters.Add(voter);
                    model.SaveChanges();
                    voterdetail.voterid = voter.voterid;
                    voterEdu.voterid = voter.voterid;
                    //voterEdu.educationid = voter.voterid;
                    voterAns.voterid = voter.voterid;
                    //voterAns.answerid = voter.voterid;
                    voterAns.sectionnumber = voterAns.sectionnumber == 0 ? voter.voterid : voterAns.sectionnumber;

                    model.VoterDetails.Add(voterdetail);
                    model.VoterEducation.Add(voterEdu);
                    model.VoterAnswers.Add(voterAns);
                    model.SaveChanges();
                }
                else
                {
                    //update record 
                    var vot = (from v in model.Voters
                                       where v.voterid == voterfound
                                       select v).FirstOrDefault();

                    var votDe = (from v in model.VoterDetails
                                       where v.voterid == voterfound
                                       select v).FirstOrDefault();

                    var votEdu = (from v in model.VoterEducation
                                       where v.voterid == voterfound
                                       select v).FirstOrDefault();

                    var votAns = (from v in model.VoterAnswers
                                       where v.voterid == voterfound
                                       select v).FirstOrDefault();


                    votDe.firstname = record.firstname;
                    votDe.middle = record.middle;
                    votDe.lastname = record.lastname;
                    votDe.email = record.email;
                    votDe.age = record.age;
                    votDe.customerid = record.customerid;
                    votDe.ssn = record.ssn;
                    votDe.gender = record.gender;
                    votDe.dob = record.dob;

                    vot.uid = record.uid;
                    vot.surveyid = record.surveyid;
                    vot.contextusername = record.contextusername;
                    vot.votedate = record.votedate;
                    vot.startdate = record.startdate;
                    vot.ipsource = record.ipsource;
                    vot.validated = record.validated;
                    vot.resumeuid = record.resumeuid;
                    vot.resumeatpagenumber = record.resumeatpagenumber;
                    vot.progresssavedate = record.progresssavedate;
                    vot.resumequestionnumber = record.resumequestionnumber;
                    vot.resumehighestpagenumber = record.resumehighestpagenumber;
                    vot.languagecode = record.languagecode;

                    votEdu.graduate = record.graduate;
                    votEdu.graduateyear = record.graduateyear;
                    votEdu.postgraduate = record.postgraduate;
                    votEdu.pgyear = record.pgyear;
                    votEdu.highdegree = record.highdegree;
                    votEdu.other = record.other;

                    votAns.sectionnumber = record.sectionnumber;
                    votAns.noshow = record.noshow;
                    votAns.answertext = record.answertext;

                    model.SaveChanges();

                }
               

            }
        }

        public static List<DataModel> GetAllRecords()
        {
            List<DataModel> returnData = new List<DataModel>();

            using (OCAT model = new OCAT())
            {
                var item = (from v in model.Voters
                            join vd in model.VoterDetails on v.voterid equals vd.voterid
                            join ve in model.VoterEducation on v.voterid equals ve.voterid
                            join va in model.VoterAnswers on v.voterid equals va.voterid
                            select new 
                            {
                                vd.firstname ,
                                vd.middle ,
                                vd.lastname ,
                                vd.email,
                                vd.age,
                                vd.customerid ,
                                vd.ssn ,
                                vd.gender ,
                                vd.dob ,

                                v.uid ,
                                v.surveyid ,
                                v.contextusername ,
                                v.votedate ,
                                v.startdate ,
                                v.ipsource ,
                                v.validated ,
                                v.resumeuid ,
                                v.resumeatpagenumber ,
                                v.progresssavedate ,
                                v.resumequestionnumber ,
                                v.resumehighestpagenumber ,
                                v.languagecode ,
                                
                                ve.graduate ,
                                ve.graduateyear ,
                                ve.postgraduate ,
                                ve.pgyear,
                                ve.highdegree ,
                                ve.other ,
                                
                                va.sectionnumber ,
                                va.noshow ,
                                va.answertext
                                });

                foreach(var record in item)
                {
                    DataModel rec = new DataModel();
                    returnData.Add(rec);
                        rec.firstname = record.firstname;
                        rec.middle = record.middle;
                        rec.lastname = record.lastname; 
                        rec.email = record.email;
                        rec.age = record.age;
                        rec.customerid = record.customerid;
                        rec.ssn = record.ssn;
                        rec.gender = record.gender;
                        rec.dob = record.dob;

                        rec.uid = record.uid;
                        rec.surveyid = record.surveyid;
                        rec.contextusername = record.contextusername;
                        rec.votedate = record.votedate;
                        rec.startdate = record.startdate;
                        rec.ipsource = record.ipsource;
                        rec.validated = record.validated;
                        rec.resumeuid = record.resumeuid;
                        rec.resumeatpagenumber = record.resumeatpagenumber;
                        rec.progresssavedate = record.progresssavedate;
                        rec.resumequestionnumber = record.resumequestionnumber;
                        rec.resumehighestpagenumber = record.resumehighestpagenumber;
                        rec.languagecode = record.languagecode;

                        rec.graduate = record.graduate;
                        rec.graduateyear = record.graduateyear;
                        rec.postgraduate = record.postgraduate;
                        rec.pgyear = record.pgyear;
                        rec.highdegree = record.highdegree;
                        rec.other = record.other;
                                
                        rec.sectionnumber = record.sectionnumber;
                        rec.noshow = record.noshow;
                        rec.answertext = record.answertext;
                }
               
            }

            return returnData;
        }

        public static DataModel GetvoterRecord(string uId)
        {
            DataModel rec = new DataModel();

            using (OCAT model = new OCAT())
            {
                var record = (from v in model.Voters
                            join vd in model.VoterDetails on v.voterid equals vd.voterid
                            join ve in model.VoterEducation on v.voterid equals ve.voterid
                            join va in model.VoterAnswers on v.voterid equals va.voterid
                            where v.uid == uId 
                            select new 
                            {
                                vd.firstname,
                                vd.middle,
                                vd.lastname,
                                vd.email,
                                vd.age,
                                vd.customerid,
                                vd.ssn,
                                vd.gender,
                                vd.dob,

                                v.uid,
                                v.surveyid,
                                v.contextusername,
                                v.votedate,
                                v.startdate,
                                v.ipsource,
                                v.validated,
                                v.resumeuid,
                                v.resumeatpagenumber,
                                v.progresssavedate,
                                v.resumequestionnumber,
                                v.resumehighestpagenumber,
                                v.languagecode,

                                ve.graduate,
                                ve.graduateyear,
                                ve.postgraduate,
                                ve.pgyear,
                                ve.highdegree,
                                ve.other,

                                va.sectionnumber,
                                va.noshow,
                                va.answertext
                            }).FirstOrDefault();


                if (record != null)
                {
                    rec.firstname = record.firstname;
                    rec.middle = record.middle;
                    rec.lastname = record.lastname;
                    rec.email = record.email;
                    rec.age = record.age;
                    rec.customerid = record.customerid;
                    rec.ssn = record.ssn;
                    rec.gender = record.gender;
                    rec.dob = record.dob;

                    rec.uid = record.uid;
                    rec.surveyid = record.surveyid;
                    rec.contextusername = record.contextusername;
                    rec.votedate = record.votedate;
                    rec.startdate = record.startdate;
                    rec.ipsource = record.ipsource;
                    rec.validated = record.validated;
                    rec.resumeuid = record.resumeuid;
                    rec.resumeatpagenumber = record.resumeatpagenumber;
                    rec.progresssavedate = record.progresssavedate;
                    rec.resumequestionnumber = record.resumequestionnumber;
                    rec.resumehighestpagenumber = record.resumehighestpagenumber;
                    rec.languagecode = record.languagecode;

                    rec.graduate = record.graduate;
                    rec.graduateyear = record.graduateyear;
                    rec.postgraduate = record.postgraduate;
                    rec.pgyear = record.pgyear;
                    rec.highdegree = record.highdegree;
                    rec.other = record.other;

                    rec.sectionnumber = record.sectionnumber;
                    rec.noshow = record.noshow;
                    rec.answertext = record.answertext;
                }

                return rec;
                }

            }


       
    }
}
