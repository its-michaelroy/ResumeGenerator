# <h1>ResumeGenerator</h1>

*A C# PDF Resume Generator*

`ResumeGenerator` is a **C# console application** that creates a professional, well-formatted PDF resume. Built using **.NET 8** and the **QuestPDF library**, it allows users to programmatically define their resume content and export it as a clean, structured document. The application supports generating both a **single-page** and a **two-page** resume, selectable at runtime.

---

## 📌 **Table of Contents**
- [Project Description](#project-description)
- [Features](#features)
- [Installation & Running](#installation-&-running)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Credits](#credits)
- [License](#license)

---

## <h2 id="project-description">📖 Project Description</h2>
### 🎯 **Motivation**
Creating a polished resume can be time-consuming, especially when formatting it manually in tools like Adobe, Word, or Google Docs. `ResumeGenerator` was developed to **automate this process**, providing a **programmatic, repeatable way** to generate a professional resume in PDF format with the flexibility to choose between a concise single-page version or a detailed two-page version.

### 🎯 **Purpose**
✅ Generate a **structured** resume with minimal effort  
✅ Support both **single-page** and **two-page** resume formats  
✅ Ensure **consistent formatting** across sections  
✅ Export to **PDF** for easy sharing and printing  
✅ Allow **customization** through code  

### 🎯 **Problem Solved**
Manual resume formatting is prone to errors and inconsistencies.  
`ResumeGenerator` **solves this by**:  
✔ Centralizing resume content in C# files (`SinglePage.cs` and `TwoPage.cs`)  
✔ Automating layout with **predefined styles**  
✔ Producing a **print-ready PDF** instantly  
✔ Offering a choice between single-page and two-page formats  

### 🎯 **Lessons Learned**
Building `ResumeGenerator` offered insights into:  
✔ Working with **PDF generation** in C# using QuestPDF  
✔ Structuring **complex layouts** programmatically  
✔ Managing **multiple entry points** in a single project  
✔ Handling **dependencies** via NuGet  
✔ Implementing **exception management** and file I/O in .NET  

---

## <h2 id="features">✨ Features</h2>
✅ **Single-Page and Two-Page Options** – Choose between a concise single-page resume or a detailed two-page resume  
✅ **Customizable Sections** – Define Skills, Projects, Education, and Experience  
✅ **Professional Formatting** – Bold headings, indented bullets, and aligned dates  
✅ **PDF Export** – Outputs a clean, A4-sized PDF resume  
✅ **Consistent Styling** – Uses Times New Roman with fallback fonts for readability  
✅ **Error Handling** – Logs issues during PDF generation  

---

## <h2 id="installation-&-running">🛠 Installation & Running</h2>
To install and run `ResumeGenerator` locally, follow these steps:

### **🔹 Prerequisites**
Ensure you have the following installed:  
- **.NET 8 SDK** (Install via: [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))  
  - **Troubleshooting**: If you encounter issues installing the SDK (e.g., on macOS with M1/M2 chips), refer to the [official .NET installation guide](https://learn.microsoft.com/en-us/dotnet/core/install/) for help selecting the correct installer (x64 or ARM64).

### **🔹 Steps**
1️⃣ **Clone the Repository**  
```bash
git clone https://github.com/its-michaelroy/ResumeGenerator.git
```

2️⃣ **Navigate to the Project Directory**
```bash
cd ResumeGenerator
```

3️⃣ **Restore Dependencies**
```bash
dotnet restore
```
This installs the **QuestPDF** NuGet package (version 2024.10.2 or latest).

4️⃣ **Build the Project**
```bash
dotnet build
```

5️⃣ **Run the Application**
- **Using the Command Line**:
  ```bash
  dotnet run
  ```
- **Using an IDE (e.g., Visual Studio)**: Open the solution in your IDE, set `ResumeGenerator` as the startup project, and press **Ctrl + F5** (or the "Run" button).

The program will prompt you to choose between generating a single-page or two-page resume. The generated PDF will be saved in the `Resumes` folder in the project root.

---

## <h2 id="usage">🎮 Usage</h2>
### **🔹 Generating the Resume**
1️⃣ **Run the Program**:
- In your IDE, press **Ctrl + F5** (or the "Run" button), or use `dotnet run` in the terminal.
- The program will display a menu:
  ```
  Select which resume to generate:
  1. Single-Page Resume (Michael_Roy_Software_Engineer-1pg.pdf)
  2. Two-Page Resume (Michael_Roy_Software_Engineer-2pg.pdf)
  Enter 1 for (1-page Resume) or 2 for (2-Page Resume):
  ```
- Enter `1` to generate the single-page resume (`Michael_Roy_Software_Engineer-1pg.pdf`) or `2` to generate the two-page resume (`Michael_Roy_Software_Engineer-2pg.pdf`).

2️⃣ **Check Output**:
- The generated PDF will be saved in the `Resumes/` folder in the project root (alongside `README.md`, `Program.cs`, `SinglePage.cs`, and `TwoPage.cs`). The `Resumes` folder is included in the repository, so it should already exist.

3️⃣ **Customize Content** (Optional):
- Open `SinglePage.cs` or `TwoPage.cs` in your preferred editor (e.g., Visual Studio, VS Code, Rider).
- Modify the Skills, Projects, Education, and Experience sections by updating the `Text` calls with your details.
- Run the program again to regenerate the PDF with your changes.

### **🔹 Tips**
✔ **Adjust Layout** – Tweak `Padding`, `Spacing`, or `FontSize` values in `SinglePage.cs` or `TwoPage.cs` for custom formatting.  
✔ **Change PDF Name** – Update the `outputPath` variable in `SinglePage.cs` or `TwoPage.cs` to change the name of the generated PDF (e.g., from `Michael_Roy_Software_Engineer-1pg.pdf` to `My_Resume.pdf`).  
✔ **Change Output Path** – Update the `outputPath` variable in `SinglePage.cs` or `TwoPage.cs` to save the PDF elsewhere (ensure the target directory exists).

> [!WARNING]  
> If you change the `outputPath` in `SinglePage.cs` or `TwoPage.cs`, ensure the target directory exists. If the directory is missing, the program will fail to generate the PDF.

✔ **Debug Issues** – Check the console output for error messages if the PDF fails to generate.

---

## <h2 id="screenshots">📸 Screenshots</h2>
### 📍 Code Overview
The code defines the resume content and saves it to the `Resumes` folder.  
![Code Overview](Images/code-overview.png)

### 📍 Generated Resumes
The output PDFs are professional, well-formatted resumes.
- **Single-Page Resume**:  
  ![Single-Page Resume](Images/resume-output-1pg.png)
- **Two-Page Resume**:  
  ![Two-Page Resume Page 1](Images/resume-output-2.1pg.png)  
  ![Two-Page Resume Page 2](Images/resume-output-2.2pg.png)

---

## <h2 id="credits">💡 Credits</h2>
👨‍💻 **Developer:** [Michael Roy](https://github.com/its-michaelroy)  
📚 **Resources:**
- **[QuestPDF](https://github.com/QuestPDF/QuestPDF)** – An open-source .NET library for PDF generation, created by the QuestPDF team. Visit their website at [www.questpdf.com](https://www.questpdf.com/) for documentation and support. This project relies on QuestPDF (NuGet package: `QuestPDF`, version 2024.10.2) for its core functionality.
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/) – Official .NET 8 SDK and C# resources

Special thanks to the **QuestPDF team** for providing a powerful, easy-to-use library that made this project possible!

---

## <h2 id="license">📜 License</h2>
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.