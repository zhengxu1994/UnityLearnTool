/*
* LCL support c# hotfix here.
*Copyright(C) LCL.All rights reserved
* URL:https://github.com/qq576067421/cshotfix
*QQ:576067421
* QQ Group: 673735733
* Licensed under the MIT License (the 'License'); you may not use this file except in compliance with the License. You may obtain a copy of the License at
* 
* Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 'AS IS' BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using CSHotFix.CLR.Method;
using CSHotFix.Runtime.Enviorment;
using CSHotFix.Runtime.Intepreter;
public class AdapterRegister
    {
        public static void RegisterCrossBindingAdaptor(CSHotFix.Runtime.Enviorment.AppDomain domain)
        {
domain.RegisterCrossBindingAdaptor(new IGameHotFixInterfaceAdapter());
}
}