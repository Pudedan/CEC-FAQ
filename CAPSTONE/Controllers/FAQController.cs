using CAPSTONE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CAPSTONE.Controllers
{
    public class FAQController : Controller
    {
        public static List<FAQ> faqs = new List<FAQ>()
        {
            // Enrollment
            new FAQ { Id = 1, Question = "How do I enroll?", Answer = "To enroll, you must visit the school located at Leon Kilat Street, Pahina Central, Cebu City, Philippines, as online enrollment is not currently available. Please ensure that you bring all the required documents with you when you go to the school.", Category = "Enrollment" },

            new FAQ { Id = 2, Question = "What are the enrollment requirements?", Answer = "You are required to bring your birth certificate, 2x2 picture, and report card. If you are a scholar, you must also present your scholarship certificate. If not, you should be prepared to pay the required tuition fee.", Category = "Enrollment" },

            new FAQ { Id = 3, Question = "When is enrollment period?", Answer = "The enrollment period usually begins in June; however, the exact schedule may vary each year. It is recommended to contact the school for the official dates.", Category = "Enrollment" },

            new FAQ { Id = 4, Question = "Is online enrollment available?", Answer = "No, online enrollment is currently not available. Students are required to visit the school for the enrollment process.", Category = "Enrollment" },

            new FAQ { Id = 5, Question = "Is there an entrance exam?", Answer = "No, there is no entrance examination required for any of the courses offered by the school.", Category = "Enrollment" },

            // Academics
            new FAQ { Id = 6, Question = "What courses are offered?", Answer = "The school offers several programs, including Bachelor of Secondary Education (BSED), Bachelor of Elementary Education (BEED), Bachelor of Science in Tourism Management (BSTM), Bachelor of Science in Hospitality Management (BSHM), Bachelor of Science in Information Technology (BSIT), and Bachelor of Science in Criminology (BSCRIM).", Category = "Academics" },

            new FAQ { Id = 7, Question = "Do you offer all grade levels?", Answer = "Yes, the school offers all grade levels, providing education for a wide range of students.", Category = "Academics" },

            new FAQ { Id = 8, Question = "What is CSS?", Answer = "Computer System Servicing (CSS) is a technical course that focuses on the installation, maintenance, and troubleshooting of computer systems. It is different from Cascading Style Sheets (CSS), which is used in web development.", Category = "Academics" },

            new FAQ { Id = 9, Question = "Are there practical activities?", Answer = "Yes, the school provides various practical activities designed to enhance the skills and competencies of students.", Category = "Academics" },

            new FAQ { Id = 10, Question = "Do you provide certificates or awards?", Answer = "Yes, students may receive certificates, medals, and even cash incentives as recognition for their academic achievements.", Category = "Academics" },

            // Facilities
            new FAQ { Id = 11, Question = "Do you have computer labs?", Answer = "Yes, the school currently has four computer laboratories, with additional facilities under construction to further improve resources.", Category = "Facilities" },

            new FAQ { Id = 12, Question = "Is there a library?", Answer = "Yes, the school has a library that provides students with access to educational materials and resources.", Category = "Facilities" },

            new FAQ { Id = 13, Question = "Is there internet access?", Answer = "There is currently no internet access available; however, the library provides computers that students can use strictly for educational purposes.", Category = "Facilities" },

            new FAQ { Id = 14, Question = "Are rooms air-conditioned?", Answer = "Air-conditioning is available only in laboratories and faculty rooms.", Category = "Facilities" },

            new FAQ { Id = 15, Question = "Do you have ICT labs?", Answer = "Yes, the school provides ICT laboratories for students.", Category = "Facilities" },

            // Support
            new FAQ { Id = 16, Question = "Who can I contact?", Answer = "You may contact the school through the following mobile number: 0995 834 4650.", Category = "Support" },

            new FAQ { Id = 17, Question = "Do you offer support services?", Answer = "Yes, the school provides support services such as academic guidance and assistance to students.", Category = "Support" },

            new FAQ { Id = 18, Question = "Who handles technical issues?", Answer = "Technical concerns are handled by the school’s IT staff or designated personnel.", Category = "Support" },

            new FAQ { Id = 19, Question = "Is academic advising available?", Answer = "Yes, academic advising is available to guide students in their educational journey.", Category = "Support" },

            new FAQ { Id = 20, Question = "Can documents be requested online?", Answer = "Some document requests may be available depending on the school’s current services.", Category = "Support" },

            // General
            new FAQ { Id = 21, Question = "What are the school hours?", Answer = "School schedules depend on the student’s study load. Some classes are conducted in the morning, while others are scheduled in the evening.", Category = "General" },

            new FAQ { Id = 22, Question = "What is the dress code?", Answer = "Students are required to wear the official school uniform. Pants and shoes may vary as long as they are appropriate. Female students are required to wear a hairnet, while male students must maintain a clean-cut hairstyle.", Category = "General" },

            new FAQ { Id = 23, Question = "Are there extracurricular activities?", Answer = "Yes, the school offers extracurricular activities that help students develop their talents and interests.", Category = "General" },

            new FAQ { Id = 24, Question = "Is the school private or public?", Answer = "Cebu Eastern College is a private educational institution.", Category = "General" },

            new FAQ { Id = 25, Question = "Are scholarships available?", Answer = "The school offers various scholarship programs, including TESDA, CHED, Sugbo Scholarship, Cebu City College Scholarship, and other available opportunities.", Category = "General" },

            // Finance
            new FAQ { Id = 26, Question = "How much is the tuition fee?", Answer = "The tuition fee varies depending on the selected program. It is recommended to contact the school for detailed information.", Category = "Finance" },

            new FAQ { Id = 27, Question = "Are installment options available?", Answer = "Yes, the school allows installment payment options to make tuition fees more manageable for students.", Category = "Finance" },

            new FAQ { Id = 28, Question = "Are there additional fees?", Answer = "Additional fees may include laboratory fees, miscellaneous fees, and other school-related expenses.", Category = "Finance" },

            new FAQ { Id = 29, Question = "How can I pay?", Answer = "Payments can be made through the school cashier or other approved payment methods provided by the school.", Category = "Finance" },

            new FAQ { Id = 30, Question = "Are receipts provided?", Answer = "Yes, official receipts are issued for every payment made to ensure proper documentation and transparency.", Category = "Finance" }
        };

        public IActionResult Index(string category)
        {
            var result = faqs.AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                result = result.Where(f =>
                    f.Category != null &&
                    f.Category.ToLower().Trim() == category.ToLower().Trim());
            }

            return View(result.ToList());
        }

        public IActionResult Admin()
        {
            return View(faqs);
        }

        [HttpPost]
        public IActionResult Add(FAQ faq)
        {
            faq.Id = faqs.Count + 1;
            faqs.Add(faq);
            return RedirectToAction("Admin");
        }

        public IActionResult Delete(int id)
        {
            var item = faqs.FirstOrDefault(f => f.Id == id);
            if (item != null) faqs.Remove(item);
            return RedirectToAction("Admin");
        }
    }
}