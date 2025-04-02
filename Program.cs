// See https://aka.ms/new-console-template for more information

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
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
            string outputPath = Path.Combine(projectRoot, "Resumes", "Michael_Roy_Software_Engineer.pdf");
            string absolutePath = Path.GetFullPath(outputPath);
            Console.WriteLine($"Attempting to save PDF to: {absolutePath}");

            // Ensure the 'Resumes' folder exists
            string resumesFolder = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(resumesFolder))
            {
                throw new DirectoryNotFoundException($"The 'Resumes' folder was not found at '{resumesFolder}'. Please ensure the folder exists in the project root.");
            }

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(0.9f, Unit.Centimetre);
                    // Use Times New Roman, with fallbacks to Lato and Calibri
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Times New Roman", Fonts.Lato, "Calibri"));

                    // Header (Centered)
                    page.Header()
                        .ShowOnce() // Restricts header to first page
                        .PaddingVertical(-0.9f, Unit.Centimetre) // Pulls name in Header closer to Top Margin.
                        .PaddingBottom(-0.5f, Unit.Centimetre)
                        //.AlignCenter()
                        .Column(column =>
                        {
                            column.Spacing(1.4f);
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
                                .Text("github.com/its-michaelroy | 412-763-1887 | in/michaelroy91/ | Michael.roy@mrcodewizard.com")
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
                            column.Spacing(5);

                            // Languages & Tools
                            //column.Item().Text("SKILLS").FontSize(14).Bold();
                            //column.Item().LineHorizontal(2).LineColor(Colors.Black); // Section break underline
                            // Space after header underline, independent of heading
                            column.Item().PaddingTop(40).Column(skills =>
                            {
                                skills.Spacing(3);
                                skills.Item().Row(row =>
                                {
                                    //row.ConstantItem(10).Text("•");
                                    row.RelativeItem().Text("Languages: JavaScript ES6, Typescript, C#, React 17, PostgreSQL, Firebase, HTML, CSS").Bold();
                                });
                                skills.Item().Row(row =>
                                {
                                   // row.ConstantItem(10).Text("•");
                                    row.RelativeItem().Text("Tools: Git, Github Actions, Terraform, Ansible, Docker").Bold();
                                });
                                skills.Item().Row(row =>
                                {
                                    //row.ConstantItem(10).Text("•");
                                    row.RelativeItem(11).Text("Certs: CompTIA Security+, AWS Cloud Practitioner, SAFe Agile (SP), AWS Solutions Architect Associate (Pending)").Bold();
                                });
                            });

                            // Projects
                            column.Item().PaddingTop(1.2f); // Space before the new section
                            column.Item().Text("PROJECTS").FontSize(14).Bold();
                            column.Item().LineHorizontal(1).LineColor(Colors.Black); // Section break underline
                            column.Item().PaddingTop(5).Column(proj =>
                            {
                                proj.Spacing(3);
                                // FlashAce AI Study Tool
                                proj.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(t =>
                                    {
                                        t.Span("FlashAce AI Study Tool - ").Bold();
                                        t.Span("github.com/Headstarters/Flash-card-app").FontColor(Colors.DeepPurple.Accent4).Bold();
                                    });
                                    row.ConstantItem(80).AlignRight().Text("Aug 2024").Bold();
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Dynamic AI flashcard application with study mode, allowing users to generate custom decks for efficient learning");
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Built using Next, React, JavaScript ES6, MUI, Firebase, Clerk, OpenAI, and Stripe API");
                                });

                                // Deep Impact
                                proj.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(t =>
                                    {
                                        t.Span("Deep Impact - ").Bold();
                                        t.Span("deep-impact.onrender.com ").FontColor(Colors.DeepPurple.Accent4).Bold();
                                        t.Span("- 1st Place Hackathon Winner").Bold();
                                    });
                                    row.ConstantItem(80).AlignRight().Text("May 2024").Bold();
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Web application designed to provide users with educational insights into the potential dangers of asteroid impacts");
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Built using Python, JavaScript ES6, Django, React and hosted on Render with NASA's Sentry API");
                                });

                                // Platoon Console
                                proj.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(t =>
                                    {
                                        t.Span("Platoon Console - ").Bold();
                                        t.Span("github.com/L-Carr/Platoon-Console").FontColor(Colors.DeepPurple.Accent4).Bold();
                                    });
                                    row.ConstantItem(80).AlignRight().Text("Apr 2024").Bold();
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Web application dashboard for managing Code Platoon cohorts, offering centralized access to course materials");
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Built using Python, JavaScript ES6, Django, React, and a PostgreSQL database with Google API");
                                });

                                // Validation Station
                                proj.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(t =>
                                    {
                                        t.Span("Validation Station - ").Bold();
                                        t.Span("github.com/its-michaelroy/ValidationStation").FontColor(Colors.DeepPurple.Accent4).Bold();
                                    });
                                    row.ConstantItem(80).AlignRight().Text("Mar 2024").Bold();
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("App for validating emails and phone numbers, with results and details displayed via a user-friendly interface");
                                });
                                proj.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Built using Python, JavaScript ES6, Django, React, and a PostgreSQL database with BigDataCloud API");
                                });
                            });

                            // Education
                            column.Item().PaddingTop(1.2f); // Space before the new section
                            column.Item().Text("EDUCATION").FontSize(14).Bold();
                            column.Item().LineHorizontal(1).LineColor(Colors.Black); // Section break underline
                            column.Item().PaddingTop(5).Column(edu =>
                            {
                                edu.Spacing(3);
                                edu.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("DevOps & Cloud Engineer | Code Platoon").Bold();
                                    row.ConstantItem(100).AlignRight().Text("May 2024-Oct 2024").Bold();
                                });
                                edu.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Created AWS environments, deployed apps using Terraform, Ansible, and Github Actions");
                                });

                                edu.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Software Engineer | Code Platoon").Bold();
                                    row.ConstantItem(100).AlignRight().Text("Feb 2024-May 2024").Bold();
                                });
                                edu.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("700+ hour software engineer curriculum using React, JavaScript, SQL, Git, TDD, and Agile");
                                });

                                edu.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Bachelor of Science Information Technology | Slippery Rock University").Bold();
                                    row.ConstantItem(100).AlignRight().Text("Aug 2013-May 2017").Bold();
                                });
                                edu.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Coursework in JavaScript, Scripting languages, Data Structures and Algorithms, and C++ programming");
                                });
                            });

                            // Professional Experience
                            column.Item().PaddingTop(1.2f); // Space before the new section
                            column.Item().Text("PROFESSIONAL EXPERIENCE").FontSize(14).Bold();
                            column.Item().LineHorizontal(1).LineColor(Colors.Black); // Section break underline
                            column.Item().PaddingTop(5).Column(exp =>
                            {
                                exp.Spacing(3);
                                exp.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Software Engineering Fellow | Headstarter AI").Bold();
                                    row.ConstantItem(95).AlignRight().Text("July 2024-Present").Bold();
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Developed 5+ AI-powered apps including an Inventory system, using Next.js, JavaScript, OpenAI, and Stripe API");
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Enhancing a green contractor startup's app through data analysis, AI optimization, and code refactoring");
                                });

                                exp.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Data Center Technician | Oracle").Bold();
                                    row.ConstantItem(95).AlignRight().Text("June 2022-Feb 2024").Bold();
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Collaborated with team using JIRA in testing initiatives, resolving over 90 hardware and software issues, achieving 99.99% uptime, improving stability, and saving the company over $65K");
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Performed database tuning and indexing to enhance query performance across data center infrastructure");
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Configured Exadata X7-2L servers with the development team utilizing scripts to optimize rack environments");
                                });

                                exp.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Information Technology Specialist - Tier 3 | TEKSystems").Bold();
                                    row.ConstantItem(95).AlignRight().Text("Feb 2021-June 2022").Bold();
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Created automated scripts for Office 365 and Outlook for user account setup, troubleshooting software, network, and vpn applications, resulting in 35% faster resolution and improved employee satisfaction");
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Deployed and configured 300+ thin clients, assisted network team with Cisco access points, and provided on-site support for critical data center projects as needed, ensuring seamless operations for federal employees");
                                });

                                exp.Item().Row(row =>
                                {
                                    row.RelativeItem().Text("Systems Analyst - Tier 3 | Arnett Carbis Toothman").Bold();
                                    row.ConstantItem(95).AlignRight().Text("Apr 2017-Feb 2021").Bold();
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Developed automated scripts to streamline IT operations, including user login audits, and server maintenance, resulting in a 20% average reduction in downtime for 900+ computers, and 90 servers across 30+ clients");
                                });
                                exp.Item().Row(row =>
                                {
                                    row.ConstantItem(20);
                                    row.ConstantItem(11).Text("•").FontSize(14);
                                    row.RelativeItem().Text("Advised on IT and security solutions, cutting incidents by 25% and boosting network efficiency by 30%");
                                });
                            });
                        });

                    // Footer
                    // page.Footer()
                    //     .AlignCenter()
                    //     .Text(t => t.CurrentPageNumber().FontSize(8));
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