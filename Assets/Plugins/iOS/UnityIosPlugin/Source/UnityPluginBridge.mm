//
//  UnityPluginBridge.m
//  UnityIosPlugin
//
//  Created by YOUNGIL CHUNG on 3/22/24.
//

#import <Foundation/Foundation.h>
#include "UnityFramework/UnityIosPlugin-Swift.h"

extern "C" {
#pragma mark - functions

int _addTwoNumberInIOS(int a, int b){
    int result = [[UnityPlugin shared] AddTwoNumberWithA:(a) b:(b)];
    return result;
}
}
