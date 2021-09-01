// <copyright file="PexAssemblyInfo.cs">Copyright ©  2019</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("Project")]
[assembly: PexInstrumentAssembly("System.Drawing")]
[assembly: PexInstrumentAssembly("LemmaSharp")]
[assembly: PexInstrumentAssembly("LemmaSharpPrebuilt")]
[assembly: PexInstrumentAssembly("LemmaSharpPrebuiltCompact")]
[assembly: PexInstrumentAssembly("stanford-postagger-3.9.1")]
[assembly: PexInstrumentAssembly("System.Windows.Forms")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("IKVM.OpenJDK.Core")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Drawing")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "LemmaSharp")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "LemmaSharpPrebuilt")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "LemmaSharpPrebuiltCompact")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "stanford-postagger-3.9.1")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Windows.Forms")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "IKVM.OpenJDK.Core")]

