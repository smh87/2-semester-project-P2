# P2
P2 plagiarism

  -setup
  1. download
  2. extract to a folder

  -installation
  1. Open project.sln in visual studio (Project/Project.sln)
  2. Run in Visual studio

  If program fails to run verify that you have:
  1. installed the right NuGet packages
  2. If the packages is installed, uninstall the packages in the following order:
        - Stanford.NLP.POSTagger
        - IKVM
  3. reinstall the packages (just reinstall Stanford.NLP.POSTagger, the other package will follow)
  4. run again
