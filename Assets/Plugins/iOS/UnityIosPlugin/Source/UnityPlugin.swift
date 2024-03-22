//
//  UnityPlugin.swift
//  UnityIosPlugin
//
//  Created by YOUNGIL CHUNG on 3/22/24.
//

import Foundation

@objc public class UnityPlugin : NSObject {
    @objc public static let shared = UnityPlugin()
    @objc public func AddTwoNumber(a:Int, b:Int) -> Int {
        let result = a + b
        return result
    }
}
