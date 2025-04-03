// See https://aka.ms/new-console-template for more information

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Reflection;

namespace ResumeGenerator
{
    class TwoPage
    {
        public static void RunTwoPage(string[] args)
        {
            // Configure the Community License
            QuestPDF.Settings.License = LicenseType.Community;

            try
            {
                // Get the project root directory by navigating up from the executing assembly's location
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
                // Navigate up three levels from /bin/Debug/net8.0 to the project root
                string projectRoot = Path.GetFullPath(Path.Combine(assemblyDirectory, "..", "..", ".."));

                // Define the output path in the 'Resumes' folder in the project root
                string outputPath = Path.Combine(projectRoot, "Resumes", "Michael_Roy_Software_Engineer-2pg.pdf");
                string absolutePath = Path.GetFullPath(outputPath);
                Console.WriteLine($"Attempting to save PDF to: {absolutePath}");

                // Ensure the 'Resumes' folder exists
                string resumesFolder = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(resumesFolder))
                {
                    throw new DirectoryNotFoundException(
                        $"The 'Resumes' folder was not found at '{resumesFolder}'. Please ensure the folder exists in the project root.");
                }

                Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(0.8f, Unit.Centimetre);
                            // Use Times New Roman, with fallbacks to Lato and Calibri
                            page.DefaultTextStyle(x =>
                                x.FontSize(11).FontFamily("Times New Roman", Fonts.Lato, "Calibri"));

                            // Header (Centered)
                            page.Header()
                                .ShowOnce() // Restricts header to first page
                                .PaddingVertical(-0.5f, Unit.Centimetre) // Pulls name in Header closer to Top Margin.
                                .PaddingBottom(-0.9f, Unit.Centimetre)
                                .Column(column =>
                                {
                                    column.Spacing(2);
                                    column.Item()
                                        .AlignCenter()
                                        .Text("MICHAEL ROY")
                                        .FontSize(18).Bold().FontColor(Colors.Black);
                                    column.Item()
                                        .AlignCenter()
                                        .Text("Software Engineer | Veteran | Technical Team Lead")
                                        .FontSize(14).Bold();
                                    column.Item()
                                        .AlignCenter()
                                        .Text(
                                            "github.com/its-michaelroy | 412-763-1887 | in/michaelroy91/ | Michael.roy@mrcodewizard.com")
                                        .FontSize(12);
                                    column.Item()
                                        .PaddingTop(1.5f) // Space before the underline
                                        .LineHorizontal(2).LineColor(Colors.Black); // Underline below contact info
                                });

                            // Content
                            page.Content()
                                .PaddingVertical(1)
                                .Column(column =>
                                {
                                    // Remove parent column spacing to control spacing explicitly
                                    column.Spacing(0);

                                    // Languages & Tools
                                    column.Item().PaddingTop(47).PaddingBottom(15).Column(skills =>
                                    {
                                        skills.Spacing(3);
                                        skills.Item().Row(row =>
                                        {
                                            row.RelativeItem()
                                                .Text(
                                                    "Languages: JavaScript ES6, Typescript, C#, React 17, PostgreSQL, Firebase, HTML, CSS")
                                                .Bold();
                                        });
                                        skills.Item().Row(row =>
                                        {
                                            row.RelativeItem()
                                                .Text("Tools: Git, Github Actions, Terraform, Ansible, Docker").Bold();
                                        });
                                        skills.Item().Row(row =>
                                        {
                                            row.RelativeItem()
                                                .Text(
                                                    "Certs: CompTIA Security+, AWS Cloud Practitioner, SAFe Agile (SP), AWS Solutions Architect Associate (Pending)")
                                                .Bold();
                                        });
                                    });

                                    // Projects
                                    column.Item().PaddingVertical(3).Column(section =>
                                    {
                                        section.Item().Text("PROJECTS").FontSize(14).Bold();
                                        section.Item().LineHorizontal(1)
                                            .LineColor(Colors.Black); // Section break underline
                                        section.Item().PaddingTop(5).Column(proj =>
                                        {
                                            proj.Spacing(2);
                                            // HamStudyX Tool
                                            proj.Item().PaddingVertical(5).Column(project =>
                                            {
                                                project.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text(t =>
                                                    {
                                                        t.Span("HamStudyX - ").Bold();
                                                        t.Span("github.com/its-michaelroy/HamStudyX")
                                                            .FontColor(Colors.DeepPurple.Accent4).Bold();
                                                    });
                                                    row.ConstantItem(80).AlignRight().Text("Jan 2025").Bold();
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "HamStudyX is a cross-platform mobile application designed to help users prepare for ham radio licensing exams");
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Built using .NET MAUI, it provides a structured way to practice multiple-choice and open-ended questions, track progress, and review quiz history");
                                                });
                                            });
                                            proj.Item().Height(1); // Adds 1 points of empty space

                                            proj.Item().PaddingVertical(5).Column(project =>
                                            {
                                                project.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text(t =>
                                                    {
                                                        t.Span("FlashAce AI Study Tool - ").Bold();
                                                        t.Span("github.com/Headstarters/Flash-card-app")
                                                            .FontColor(Colors.DeepPurple.Accent4).Bold();
                                                    });
                                                    row.ConstantItem(80).AlignRight().Text("Aug 2024").Bold();
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Dynamic AI flashcard application with study mode, allowing users to generate custom decks for efficient learning");
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Built using Next, React, JavaScript ES6, MUI, Firebase, Clerk, OpenAI, and Stripe API");
                                                });
                                            });

                                            // Deep Impact
                                            proj.Item().PaddingVertical(5).Column(project =>
                                            {
                                                project.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text(t =>
                                                    {
                                                        t.Span("Deep Impact - ").Bold();
                                                        t.Span("deep-impact.onrender.com ")
                                                            .FontColor(Colors.DeepPurple.Accent4).Bold();
                                                        t.Span("- 1st Place Hackathon Winner").Bold();
                                                    });
                                                    row.ConstantItem(80).AlignRight().Text("May 2024").Bold();
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Web application designed to provide users with educational insights into the potential dangers of asteroid impacts");
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Built using Python, JavaScript ES6, Django, React and hosted on Render with NASA's Sentry API");
                                                });
                                            });

                                            // Platoon Console
                                            proj.Item().PaddingVertical(5).Column(project =>
                                            {
                                                project.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text(t =>
                                                    {
                                                        t.Span("Platoon Console - ").Bold();
                                                        t.Span("github.com/L-Carr/Platoon-Console")
                                                            .FontColor(Colors.DeepPurple.Accent4).Bold();
                                                    });
                                                    row.ConstantItem(80).AlignRight().Text("Apr 2024").Bold();
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Web application dashboard for managing Code Platoon cohorts, offering centralized access to course materials");
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Built using Python, JavaScript ES6, Django, React, and a PostgreSQL database with Google API");
                                                });
                                            });

                                            // Validation Station
                                            proj.Item().PaddingVertical(5).Column(project =>
                                            {
                                                project.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text(t =>
                                                    {
                                                        t.Span("Validation Station - ").Bold();
                                                        t.Span("github.com/its-michaelroy/ValidationStation")
                                                            .FontColor(Colors.DeepPurple.Accent4).Bold();
                                                    });
                                                    row.ConstantItem(80).AlignRight().Text("Mar 2024").Bold();
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "App for validating emails and phone numbers, with results and details displayed via a user-friendly interface");
                                                });
                                                project.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Built using Python, JavaScript ES6, Django, React, and a PostgreSQL database with BigDataCloud API");
                                                });
                                            });
                                        });
                                    });

                                    // Education
                                    column.Item().PaddingVertical(8).Column(section =>
                                    {
                                        section.Item().Text("EDUCATION").FontSize(14).Bold();
                                        section.Item().LineHorizontal(1)
                                            .LineColor(Colors.Black); // Section break underline
                                        section.Item().PaddingTop(5).Column(edu =>
                                        {
                                            edu.Spacing(2);
                                            // DevOps & Cloud Engineer
                                            edu.Item().PaddingVertical(5).Column(entry =>
                                            {
                                                entry.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("DevOps & Cloud Engineer | Code Platoon").Bold();
                                                    row.ConstantItem(100).AlignRight().Text("May 2024-Oct 2024")
                                                        .Bold();
                                                });
                                                entry.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Created AWS environments, deployed apps using Terraform, Ansible, and Github Actions");
                                                });
                                            });

                                            // Software Engineer
                                            edu.Item().PaddingVertical(5).Column(entry =>
                                            {
                                                entry.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text("Software Engineer | Code Platoon")
                                                        .Bold();
                                                    row.ConstantItem(100).AlignRight().Text("Feb 2024-May 2024")
                                                        .Bold();
                                                });
                                                entry.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "700+ hour software engineer curriculum using React, JavaScript, SQL, Git, TDD, and Agile");
                                                });
                                            });

                                            // Bachelor of Science
                                            edu.Item().PaddingVertical(5).Column(entry =>
                                            {
                                                entry.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Bachelor of Science Information Technology | Slippery Rock University")
                                                        .Bold();
                                                    row.ConstantItem(100).AlignRight().Text("Aug 2013-May 2017")
                                                        .Bold();
                                                });
                                                entry.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Coursework in JavaScript, Scripting languages, Data Structures and Algorithms, and C++ programming");
                                                });
                                            });
                                        });
                                    });

                                    // Professional Experience
                                    column.Item().PaddingVertical(3).Column(section =>
                                    {
                                        section.Item().Text("PROFESSIONAL EXPERIENCE").FontSize(14).Bold();
                                        section.Item().LineHorizontal(1)
                                            .LineColor(Colors.Black); // Section break underline
                                        section.Item().PaddingTop(5).Column(exp =>
                                        {
                                            exp.Spacing(2);
                                            // Software Engineering Fellow
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("Software Engineering Fellow | Headstarter AI")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("July 2024-Present")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .PaddingVertical(2)
                                                        .Text(
                                                            "Developed 5+ AI-powered apps including an Inventory system, using Next.js, JavaScript, OpenAI, and Stripe API");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Enhancing a green contractor startup's app through data analysis, AI optimization, and code refactoring");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Designed and implemented a user authentication system using Clerk for an AI-powered Flash Card application, improving security and enabling seamless user onboarding");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Data Center Technician
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem().Text("Data Center Technician | Oracle")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("June 2022-Feb 2024")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Collaborated with team using JIRA in testing initiatives, resolving over 90 hardware and software issues, achieving 99.99% uptime, improving stability, and saving the company over $65K");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Performed database tuning and indexing to enhance query performance across data center infrastructure");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Configured Exadata X7-2L servers with the development team utilizing scripts to optimize rack environments");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Information Technology Specialist
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Information Technology Specialist - Tier 3 | TEKSystems")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("Feb 2021-June 2022")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Created automated scripts for Office 365 and Outlook for user account setup, troubleshooting software, network, and vpn applications, resulting in 35% faster resolution and improved employee satisfaction");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Deployed and configured 300+ thin clients, assisted network team with Cisco access points, and provided on-site support for critical data center projects as needed, ensuring seamless operations for federal employees");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Collaborated with the networking team to conduct root cause analysis on recurring network outages, implementing solutions that reduced downtime by 10% and enhanced system reliability for federal operations");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Systems Analyst - Tier 3
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("Systems Analyst - Tier 3 | Arnett Carbis Toothman")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("Apr 2017-Feb 2021")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Developed automated scripts to streamline IT operations, including user login audits, and server maintenance, resulting in a 20% average reduction in downtime for 900+ computers, and 90 servers across 30+ clients");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Advised on IT and security solutions, cutting incidents by 25% and boosting network efficiency by 30%");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Installed and configured monitoring tools to track resource usage across servers, identifying bottlenecks and improving system performance by 15% for critical applications");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // IT Systems & Network Security Intern | YMCA
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("IT Systems & Network Security Intern | YMCA")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("May 2017-July 2017")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Upgraded Windows Hypervisor Server, Virtual Machines, Sophos Firewall, routers, and access points, optimizing network performance and security for 50+ users");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Automated Active Directory with scripts for user and computer logging and inventory, updated local policies in Active Directory, deployed Microsoft Office and antivirus, and created new employee hiring documentation which improved onboarding efficiency by 30%");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Configured CCTV firewall access for CEO’s phone, migrated domain to Google registrar, monitored logs, replaced 20+ desktops and laptops, and fixed childcare entry system, enhancing security and reliability");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Systems Analyst – ISD Summer Associate
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("Systems Analyst – ISD Summer Associate | UPMC")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("May 2016-Aug 2016")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .PaddingVertical(2)
                                                        .Text(
                                                            "Supported Electronic Medical Record training for ARIA and GO-LIVE implementation for CancerCenters");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Resolved issues with supported hardware devices including Dymo label printers, HP printers, All-In-One PCs, desktops and laptops including off-site issues utilizing remote desktop applications");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Reimaged new AIO’s for refresh project including installation of drivers for Single Sign-On, Epsom label printers, HP printers, scanners, and Sentillion Vergence for Citrix environment compatibility");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Lead IT Specialist
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("Lead IT Specialist | ARMY NATIONAL GUARD UNIT 2BSTB")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("Nov 2014-Nov 2020")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .PaddingVertical(2)
                                                        .Text(
                                                            "Develop hands-on experience maintaining, processing and troubleshooting computer networks, hardware and software");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Support classified logistics data by building tunnel configurations, and utilizing the satellite transportable terminal");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Implemented security protocols for network systems, ensuring compliance with DoD standards and reducing vulnerabilities by 20%");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Military Police
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text("Military Police | ARMY RESERVE UNIT 363").Bold();
                                                    row.ConstantItem(95).AlignRight().Text("July 2010-Nov 2014")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Deployed to Bagram, Afghanistan to work 12-14 hour duty days at the Parwan Province Detainment facility as well as train members of the Afghan National Army on proper procedures and conduct for overseeing detainees (February 2012-November 2012)");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().PaddingVertical(2).Text(
                                                        "Obtained Secret Clearance and gained excellent interpersonal communication skills while interacting with interpreters, detainees, and other members of the United States and Afghan National Army");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Completed a Warrior Leadership Course through the Non-Commissioned Officer School which focused on leadership training capabilities and development including land navigation and tactical Ops");
                                                });
                                            });
                                            //exp.Item().Height(1); // Adds 1 points of empty space

                                            // Dental Specialist
                                            exp.Item().PaddingVertical(6).Column(job =>
                                            {
                                                job.Item().Row(row =>
                                                {
                                                    row.RelativeItem()
                                                        .Text(
                                                            "Dental Specialist | ARMY RESERVE UNIT 339 COMBAT SUPPORT HOSPITAL")
                                                        .Bold();
                                                    row.ConstantItem(95).AlignRight().Text("July 2008-July 2010")
                                                        .Bold();
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem()
                                                        .PaddingVertical(2)
                                                        .Text(
                                                            "Supported a Combat Support Hospital by completing field training exercises, ensuring readiness for emergency dental care in high-stress deployment scenarios");
                                                });
                                                job.Item().Row(row =>
                                                {
                                                    row.ConstantItem(20);
                                                    row.ConstantItem(11).Text("•").FontSize(14);
                                                    row.RelativeItem().Text(
                                                        "Earned and maintained certifications, including X-ray and Basic Life Support (BLS), demonstrating commitment to professional standards and adaptability in a dynamic military environment");
                                                });
                                            });
                                        });
                                    });
                                });
                        });
                    })
                    .GeneratePdf(outputPath);

                Console.WriteLine("PDF generated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating PDF: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}