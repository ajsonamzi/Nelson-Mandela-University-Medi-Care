using MediCare2._0.Controllers;
using MediCare2._0.Data;
using MediCare2._0.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace MediCare2._0.Migrations
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MediCare2_0Context>();
                context.Database.EnsureCreated();
                //DrugAdmin
                if (!context.DrugAdmin.Any())
                {
                    context.DrugAdmin.AddRange(new List<DrugAdmin>()
                    {
               new DrugAdmin()
               {
                   adminType = "Oral"
               },

               new DrugAdmin()
               {
                   adminType = "Vaginal"
               },

               new DrugAdmin()
               {
                   adminType = "Rectal"
               },

               new DrugAdmin()
               {
                   adminType = "Topical"
               },

               new DrugAdmin()
               {
                   adminType = "Transdermal"
               },

               new DrugAdmin()
               {
                   adminType = "Inhalational"
               },

               new DrugAdmin()
               {
                   adminType = "Sublingual"
               },

               new DrugAdmin()
               {
                   adminType = "Injection"
               }

               });

                }
                context.SaveChanges();






                //Region
                if (!context.Region.Any())
                {
                    context.Region.AddRange(new List<Models.Region>()
                    {
               new Models.Region()
               {
                   regionName = "AFGHANISTAN",

               },
               new Region()
               {
                   regionName = "ALBANIA"
               },
               new Region()
               {
                   regionName = "ALGERIA",

               },
               new Region()
               {
                   regionName = "AMERICAN SOMOA",

               },


               new Region()
               {
                   regionName = "ANDORA",

               },

               new Region()
               {
                   regionName = "ANGOLA",

               },

               new Region()
               {
                   regionName = "ANGUILLA",

               },

               new Region()
               {
                   regionName = "ANTARCTICA",

               },

               new Region()
               {
                   regionName = "ARGENTINA",

               },

               new Region()
               {
                   regionName = "ARMENIA",

               },

               new Region()
               {
                   regionName = "AUSTRALIA",

               },

               new Region()
               {
                   regionName = "AUSTRIA",

               },

               new Region()
               {
                   regionName = "BAHAMAS",

               },

               new Region()
               {
                   regionName = "BANGLADESH",

               },

               new Region()
               {
                   regionName = "BELGIUM",

               },

               new Region()
               {
                   regionName = "BERMUDA",

               },

               new Region()
               {
                   regionName = "BOLIVIA",

               },

               new Region()
               {
                   regionName = "BOTSWANA",

               },

               new Region()
               {
                   regionName = "BRAZIL",

               },

               new Region()
               {
                   regionName = "BULGARIA",

               },
               new Region()
               {
                   regionName = "BURKINA FASO",

               },

               new Region()
               {
                   regionName = "CAMBODIA",

               },

               new Region()
               {
                   regionName = "BURKINA FASO",

               },

               new Region()
               {
                   regionName = "CAMEROON",

               },

               new Region()
               {
                   regionName = "CANADA",

               }

            });
                }
                context.SaveChanges();





                //SideEffects
                if (!context.SideEffect.Any())
                {
                    context.SideEffect.AddRange(new List<SideEffect>()
                    {
               new SideEffect()
               {
                   sideEffectName = "Insomnia ",
                   sideEffectDescription="Insomnia is a sleep disorder that regularly affects millions of people worldwide. Someone with insomnia finds it difficult to fall asleep or stay asleep.\r\n\r\n",

               },
               new SideEffect()
               {
                   sideEffectName = "Dry mouth ",
                   sideEffectDescription="Dry mouth is a symptom that results from a lack of saliva." +
                   " Individuals with dry mouth do not have enough saliva to keep their mouth wet.",

               },
                new SideEffect()
               {
                   sideEffectName = "Bladder pain ",
                   sideEffectDescription="Bladder pain can affect men and women and be caused by a few different conditions — some more serious than other",

               }

               });

                }
                context.SaveChanges();


                //Symptom

                if (!context.Symptom.Any())
                {
                    context.Symptom.AddRange(new List<Symptom>()
                    {
               new Symptom()
               {
                   symptomName = "Congestion",
                   symptomDescription="Abdominal pain describes dull or sharp aching and/or cramping in the organs and tissue " +
                   "in the area between the pelvic region and chest. Common causes can include a bellyache due to poor diet to stomach " +
                   "ulcers or, rarely, cancer of the digestive tract or abdominal organs. Most abdominal pain can be treated at home, although" +
                   " some pain indicates an underlying condition that requires medication or even surgery."

               },
                  new Symptom()
               {
                   symptomName = "Abdominal Pain",
                   symptomDescription="Congestion, or blocked nasal passages, usually occurs as a symptom of cold, flu," +
                   " or allergies, although some people feel congested because of a deviated septum. Nasal congestion has two primary causes:" +
                   " dried, inflamed sinus passages and the accumulation of mucus. Congestion can be treated at home with over-the-counter medication" +
                   ", nose drops, and by sipping hot tea or soup."

               },
                   new Symptom()
               {
                   symptomName = "Headache",
                   symptomDescription="AHeadaches are continuous pain and tension in the head and neck or behind the eyes. Tension, cluster, and migraine headaches are common headache types, caused by a variety of factors, from lack of sleep to medication use to inflammatory activity in the brain. Many headaches can be treated at home with rest and over-the-counter pain medication."

               },
                    new Symptom()
               {
                   symptomName = "Fever",
                   symptomDescription="Abdominal pain describes dull or sharp aching and/or cramping in the organs and tissue " +
                   "in the area between the pelvic region and chest. Common causes can include a bellyache due to poor diet to stomach " +
                   "ulcers or, rarely, cancer of the digestive tract or abdominal organs. Most abdominal pain can be treated at home, although" +
                   " some pain indicates an underlying condition that requires medication or even surgery."

               },
                     new Symptom()
               {
                   symptomName = "Nausea",
                   symptomDescription="A person with nausea has the feeling that they are going to vomit. " +
                   "Nausea is a common symptom of viral infections such as flu, although it can also be a symptom of " +
                   "food poisoning, altitude sickness, motion sickness, or emotional trauma."

               },
                     new Symptom()
               {
                   symptomName = "Vomiting",
                   symptomDescription="Vomiting is the unpleasant, forceful expulsion of stomach contents through the " +
                   "mouth, usually preceded by nausea. Symptoms associated with vomiting include stomach flu and other viral infections, " +
                   "excessive drug and/or alcohol consumption, food poisoning, or, less commonly, head injuries."

               }

               });

                }
                context.SaveChanges();


                //Phase
                if (!context.Contraindiction.Any())
                {
                    context.Contraindiction.AddRange(new List<Contraindication>()
                    {
                        new Contraindication()
                        {

                            contraindicationName = "Sensitivity or allergy to the medication",

                        },
                        new Contraindication()
                        {

                            contraindicationName = "Pregnancy",

                        }
               ,
                        new Contraindication()
                        {

                            contraindicationName = "Renal disease",

                        },
                        new Contraindication()
                        {

                            contraindicationName = "Hepatic disease",

                        }
                    });


                    if (!context.Alternative.Any())
                    {
                        context.Alternative.AddRange(new List<Alternative>()
                    {
               new Alternative()
               {

                   alternativeName = "Paracetamol",

               },new Alternative()
               {

                   alternativeName = "Tylenol ",

               }
               ,new Alternative()
               {

                   alternativeName = "Aspirin ",

               },
               new Alternative()
               {

                   alternativeName = "Ibuprofen ",

               }

               });

                    }
                    context.SaveChanges();



                    //Phase
                    if (!context.Phase.Any())
                    {
                        context.Phase.AddRange(new List<Phase>()
                    {
               new Phase()
               {

                   phaseStage = "Research",
                   phaseDescription= "Currently still in research and inaccessable to the public"
               },
                 new Phase()
               {

                   phaseStage = "In Production",
                    phaseDescription= "Currently in production and accessable to the public"
               },
                  new Phase()
               {

                   phaseStage = "Discontinued",
                   phaseDescription= "Discontinued from production and inaccessable to the public"
               },

               });

                    }
                    context.SaveChanges();


                    //Schedule
                    if (!context.Schedule.Any())
                    {
                        context.Schedule.AddRange(new List<Schedule>()
                    {
               new Schedule()
               {
                   scheduleNumber=0,
                   scheduleDescription = "Accessed at General shop, e.g. supermarket."
               },
               new Schedule()
               {
                   scheduleNumber=1,
                   scheduleDescription = "Accessed over the counter in a pharmacy."
               },
               new Schedule()
               {
                   scheduleNumber=2,
                   scheduleDescription = "Accessed over the counter in a pharmacy. Sale record must be kept"
               },
               new Schedule()
               {
                   scheduleNumber=3,
                   scheduleDescription = "Prescription only-allowed to repeat for 6 months. Accessed from the dispensary in the pharmacy."
               },
               new Schedule()
               {
                   scheduleNumber=4,
                   scheduleDescription = "Prescription only-allowed to repeat for 6 months. Accessed from the dispensary in the pharmacy."
               },new Schedule()
               {
                   scheduleNumber=5,
                   scheduleDescription = "Prescription only, repeats stipulated. Accessed fromthe dispensary in the pharmacy."
               },
               new Schedule()
               {
                   scheduleNumber=6,
                   scheduleDescription = "Prescription only, therapeutic narcotics."
               },
               new Schedule()
               {
                   scheduleNumber=7,
                   scheduleDescription = "Controlled substance."
               },
                new Schedule()
               {
                   scheduleNumber=8,
                   scheduleDescription = "Strictly controlled substances"
               }

               });

                    }
                    context.SaveChanges();



                    //Company
                    if (!context.Company.Any())
                    {
                        context.Company.AddRange(new List<Company>()
                    {
               new Company()
               {
                   companyName = "Aspen",
                   companyEmail= "aspen@gmail.com",
                   companyAddress="20 Rubin Cresent",
                   companyCount=2054,
                   regionID=2,

               },

               new Company()
               {
                   companyName = "J&J",
                   companyEmail= "johnson2@gmail.com",
                   companyAddress="23 Rubin Cresent",
                   companyCount=1024,
                   regionID=3,

               },

               new Company()
               {
                   companyName = "Pfizer",
                   companyEmail= "pfizer@gmail.com",
                   companyAddress="2 Rubin Cresent",
                   companyCount=876,
                   regionID=4,

               },

               new Company()
               {
                   companyName = "AstraZeneca",
                   companyEmail= "azeneca@gmail.com",
                   companyAddress="69 Rubin Cresent",
                   companyCount=8965,
                   regionID=3,

               }

               });

                    }
                    context.SaveChanges();

                    //Drug
                    if (!context.Drug.Any())
                    {
                        context.Drug.AddRange(new List<Drug>()
                         {
                    new Drug()
                    {
                        drugName = "Panado Tablet",
                        description= "Panado Tablet is indicated for the symptomatic treatment of mild to moderate pain and fever",
                        dosage="Adults: One tablet every 3 hours or one to two tablets every 4 to 6 hours while symptoms persist. ",
                        dateFirstManufactured= DateTime.Parse("1995-03-11"),
                        drugAdminID=1,
                        sideEffectID=1,
                        symptomID=1,
                        companyID=1,
                        phaseID=2,
                        alternativeID=1,
                        contraindicationID=1,
                        scheduleID=1

                    },

                         new Drug()
                    {
                     drugName = "Dexpanthenol",
                        description= "As an antacid: e.g. for the fast relief of indigestion, " +
                        "heartburn and flatulence. As a urinary alkaliniser to alleviate symptoms associated with " +
                        "inflammatory conditions of the bladder. If required, to prevent crystalluria during treatment with " +
                        "sulphonamides.",
                        dosage="As an antacid: adults: one 5 ml medicine measure or one sachet in a glass of water." ,
                        dateFirstManufactured= DateTime.Parse("1995-03-11"),
                        drugAdminID=1,
                        sideEffectID=1,
                        symptomID=5,
                        companyID=2,
                        phaseID=2,
                        alternativeID=1,
                        contraindicationID=1,
                        scheduleID=1

                    },
                           new Drug()
                    {
                     drugName = "Panado Plus",
                        description= "Panado Plus is used for the relief of headache, pain and " +
                        "inflammation of musculo-skeletal origin, feverishness, muscular, menstrual and dental pain.",
                        dosage="Two capsules every four hours, but not more than six capsules in " +
                        "twenty four hours. ",
                        dateFirstManufactured= DateTime.Parse("1995-03-11"),
                        drugAdminID=1,
                        sideEffectID=1,
                        symptomID=5,
                        companyID=2,
                        phaseID=2,
                        alternativeID=1,
                        contraindicationID=1,
                        scheduleID=1


                    }


                    });

                    }
                    context.SaveChanges();


                }
            }
        }
    }
}
