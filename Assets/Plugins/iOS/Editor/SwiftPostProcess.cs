using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public static class SwiftPostProcess
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            string projPath = PBXProject.GetPBXProjectPath(buildPath);
            PBXProject proj = new PBXProject();
            proj.ReadFromFile(projPath);

            string target = proj.GetUnityFrameworkTargetGuid();
            proj.AddBuildProperty(target, "ENABLE_BITCODE", "NO");
            proj.AddBuildProperty(target, "SWIFT_OBJC_BRIDGING_HEADER", "Libraries/Plugins/iOS/UnityIosPlugin/Source/UnityPlugin-Bridging-Header.h");
            proj.AddBuildProperty(target, "SWIFT_OBJC_INTERFACE_HEADER_NAME", "UnityIosPlugin-Swift.h");
            proj.AddBuildProperty(target, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks $(PROJECT_DIR)/lib/$(CONFIGURATION) $(inherited)");
            proj.AddBuildProperty(target, "FRAMEWORK_SEARCH_PATHS", "$(inherited) $(PROJECT_DIR)/Frameworks $(PROJECT_DIR)/Libraries/Plugins/iOS/UnityIosPlugin/Frameworks");
            proj.AddBuildProperty(target, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
            proj.AddBuildProperty(target, "DYLIB_INSTALL_NAME_BASE", "@rpath");
            proj.AddBuildProperty(target, "LD_DYLIB_INSTALL_NAME", "@executable_path/../Frameworks/$(EXECUTABLE_PATH)");
            proj.AddBuildProperty(target, "DEFINES_MODULE", "YES");
            proj.AddBuildProperty(target, "SWIFT_VERSION", "5.0");
            proj.AddBuildProperty(target, "COREML_CODEGEN_LANGUAGE", "Swift");  

            proj.WriteToFile(projPath);
        }
    }

}
