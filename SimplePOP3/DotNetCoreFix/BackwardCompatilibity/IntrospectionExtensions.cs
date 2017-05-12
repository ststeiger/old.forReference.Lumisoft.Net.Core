
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Simulates System.Reflection.TypeInfo and IntrospectionExtensions.GetTypeInfo
// for older .NET Framework-Versions (C# doesn't support extension-properties).



// #define FEATURE_LEGACY_REFLECTION_API 

#if FEATURE_LEGACY_REFLECTION_API


namespace System.Reflection
{

    public static class IntrospectionExtensions
    {
        public static System.Reflection.TypeInfo GetTypeInfo(System.Type type)
        {
            return new TypeInfo(type); ;
        }
    }


    public class TypeInfo
    {

        private System.Type t;

        public TypeInfo()
        { }

        public TypeInfo(System.Type type)
        {

            this.t = type;
        }

        public string Name => t.Name;
        public bool IsConstructedGenericType => t.IsConstructedGenericType;
        public RuntimeTypeHandle TypeHandle { get; }
        public Type DeclaringType => t.DeclaringType;


        public string AssemblyQualifiedName => t.AssemblyQualifiedName;
        public bool IsArray => t.IsArray;
        public bool IsAnsiClass => t.IsAnsiClass;
        public bool IsAbstract => t.IsAbstract;
        public bool HasElementType => t.HasElementType;
        public Guid GUID => t.GUID;
        public int GenericParameterPosition => t.GenericParameterPosition;
        public GenericParameterAttributes GenericParameterAttributes => t.GenericParameterAttributes;
        public string FullName => t.FullName;
        public MethodBase DeclaringMethod => t.DeclaringMethod;
        public bool ContainsGenericParameters => t.ContainsGenericParameters;
        public Type BaseType => t.BaseType;
        public Assembly Assembly => t.Assembly;
        public bool IsAutoClass => t.IsAutoClass;
        public Type[] GenericTypeArguments => t.GenericTypeArguments;
        public MemberTypes MemberType => t.MemberType;
        public Type UnderlyingSystemType => t.UnderlyingSystemType;
        public ConstructorInfo TypeInitializer => t.TypeInitializer;
        public System.Runtime.InteropServices.StructLayoutAttribute StructLayoutAttribute => t.StructLayoutAttribute;


        public System.Collections.Generic.IEnumerable<Type> ImplementedInterfaces => t.GetInterfaces();
        public Type[] GenericTypeParameters => t.IsGenericTypeDefinition ? t.GetGenericArguments() : System.Type.EmptyTypes;
        public System.Collections.Generic.IEnumerable<PropertyInfo> DeclaredProperties => t.GetProperties(BindingFlags.DeclaredOnly);

        public System.Collections.Generic.IEnumerable<TypeInfo> DeclaredNestedTypes
        {
            get
            {
                System.Collections.Generic.List<TypeInfo> ls =
                    new System.Collections.Generic.List<TypeInfo>();

                foreach (var t in t.GetNestedTypes(BindingFlags.DeclaredOnly))
                {
                    ls.Add(System.Reflection.IntrospectionExtensions.GetTypeInfo(t));
                }

                return ls;
            }
        }

        public System.Collections.Generic.IEnumerable<MethodInfo> DeclaredMethods => t.GetMethods(BindingFlags.DeclaredOnly);
        public System.Collections.Generic.IEnumerable<MemberInfo> DeclaredMembers => t.GetMembers(BindingFlags.DeclaredOnly);
        public System.Collections.Generic.IEnumerable<FieldInfo> DeclaredFields => t.GetFields(BindingFlags.DeclaredOnly);
        public System.Collections.Generic.IEnumerable<EventInfo> DeclaredEvents => t.GetEvents(BindingFlags.DeclaredOnly);


        public TypeAttributes Attributes => t.Attributes;
        public bool IsAutoLayout => t.IsAutoLayout;
        public bool IsByRef => t.IsByRef;
        public bool IsClass => t.IsClass;
        public bool IsValueType => t.IsValueType;
        public bool IsUnicodeClass => t.IsUnicodeClass;
        public bool IsSpecialName => t.IsSpecialName;
        public bool IsSerializable => t.IsSerializable;
        public bool IsVisible => t.IsVisible;
        public bool IsSealed => t.IsSealed;
        public bool IsPublic => t.IsPublic;
        public bool IsPrimitive => t.IsPrimitive;
        public bool IsPointer => t.IsPointer;
        public bool IsNotPublic => t.IsNotPublic;
        public bool IsNestedPublic => t.IsNestedPublic;
        public bool IsNestedPrivate => t.IsNestedPrivate;
        public bool IsNestedFamORAssem => t.IsNestedFamORAssem;
        public bool IsNestedFamily => t.IsNestedFamily;
        public bool IsNestedFamANDAssem => t.IsNestedFamANDAssem;
        public bool IsNestedAssembly => t.IsNestedAssembly;
        public bool IsNested => t.IsNested;
        public bool IsMarshalByRef => t.IsMarshalByRef;
        public bool IsLayoutSequential => t.IsLayoutSequential;
        public bool IsInterface => t.IsInterface;
        public bool IsImport => t.IsImport;
        public bool IsGenericTypeDefinition => t.IsGenericTypeDefinition;
        public bool IsGenericType => t.IsGenericType;
        public bool IsGenericParameter => t.IsGenericParameter;
        public bool IsExplicitLayout => t.IsExplicitLayout;
        public bool IsEnum => t.IsEnum;
        public bool IsCOMObject => t.IsCOMObject;

        public System.Collections.Generic.IEnumerable<ConstructorInfo> DeclaredConstructors => t.GetConstructors(BindingFlags.DeclaredOnly);
        public string Namespace => t.Namespace;
        public Type AsType() => this.t;


        public Type[] FindInterfaces(TypeFilter filter, object filterCriteria) => t.FindInterfaces(filter, filterCriteria);
        public MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria) => t.FindMembers(memberType, bindingAttr, filter, filterCriteria);
        public int GetArrayRank() => t.GetArrayRank();
        public ConstructorInfo GetConstructor(Type[] types) => t.GetConstructor(types);
        public ConstructorInfo[] GetConstructors() => t.GetConstructors();
        public ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) => t.GetConstructors(bindingAttr);

        public EventInfo GetDeclaredEvent(string name)
        {
            foreach (EventInfo ei in this.DeclaredEvents)
            {
                if (string.Equals(ei.Name, name, StringComparison.Ordinal))
                    return ei;
            }

            return null;
        }


        public FieldInfo GetDeclaredField(string name)
        {
            foreach (FieldInfo fi in this.DeclaredFields)
            {
                if (string.Equals(fi.Name, name, StringComparison.Ordinal))
                    return fi;
            }

            return null;
        }

        public MethodInfo GetDeclaredMethod(string name)
        {
            foreach (MethodInfo mi in this.DeclaredMethods)
            {
                if (string.Equals(mi.Name, name, StringComparison.Ordinal))
                    return mi;
            }

            return null;
        }


        public System.Collections.Generic.IEnumerable<MethodInfo> GetDeclaredMethods(string name)
        {
            System.Collections.Generic.List<MethodInfo> ls = new Collections.Generic.List<MethodInfo>();

            foreach (MethodInfo mi in this.DeclaredMethods)
            {
                if (string.Equals(mi.Name, name, StringComparison.Ordinal))
                    ls.Add(mi);
            }

            return ls;
        }


        public TypeInfo GetDeclaredNestedType(string name)
        {
            foreach (TypeInfo ti in this.DeclaredNestedTypes)
            {
                if (string.Equals(ti.Name, name, StringComparison.Ordinal))
                    return ti;
            }

            return null;
        }


        public PropertyInfo GetDeclaredProperty(string name)
        {

            foreach (PropertyInfo pi in this.DeclaredProperties)
            {
                if (string.Equals(pi.Name, name, StringComparison.Ordinal))
                    return pi;
            }

            return null;
        }

        public MemberInfo[] GetDefaultMembers() => t.GetDefaultMembers();
        public Type GetElementType() => t.GetElementType();
        public string GetEnumName(object value) => t.GetEnumName(value);
        public string[] GetEnumNames() => t.GetEnumNames();
        public Type GetEnumUnderlyingType() => t.GetEnumUnderlyingType();
        public Array GetEnumValues() => t.GetEnumValues();
        public EventInfo GetEvent(string name) => t.GetEvent(name);
        public EventInfo GetEvent(string name, BindingFlags bindingAttr) => t.GetEvent(name, bindingAttr);
        public EventInfo[] GetEvents() => t.GetEvents();
        public EventInfo[] GetEvents(BindingFlags bindingAttr) => t.GetEvents(bindingAttr);
        public FieldInfo GetField(string name) => t.GetField(name);
        public FieldInfo GetField(string name, BindingFlags bindingAttr) => t.GetField(name, bindingAttr);
        public FieldInfo[] GetFields() => t.GetFields();
        public FieldInfo[] GetFields(BindingFlags bindingAttr) => t.GetFields(bindingAttr);
        public Type[] GetGenericArguments() => t.GetGenericArguments();
        public Type[] GetGenericParameterConstraints() => t.GetGenericParameterConstraints();
        public Type GetGenericTypeDefinition() => t.GetGenericTypeDefinition();
        public Type GetInterface(string name) => t.GetInterface(name);
        public Type GetInterface(string name, bool ignoreCase) => t.GetInterface(name, ignoreCase);
        public Type[] GetInterfaces() => t.GetInterfaces();
        public MemberInfo[] GetMember(string name) => t.GetMember(name);
        public MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr) => t.GetMember(name, type, bindingAttr);
        public MemberInfo[] GetMember(string name, BindingFlags bindingAttr) => t.GetMember(name, bindingAttr);
        public MemberInfo[] GetMembers() => t.GetMembers();
        public MemberInfo[] GetMembers(BindingFlags bindingAttr) => t.GetMembers(bindingAttr);
        public MethodInfo GetMethod(string name) => t.GetMethod(name);
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr) => t.GetMethod(name, bindingAttr);
        public MethodInfo GetMethod(string name, Type[] types) => t.GetMethod(name, types);
        public MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers) => t.GetMethod(name, types, modifiers);
        public MethodInfo[] GetMethods() => t.GetMethods();
        public MethodInfo[] GetMethods(BindingFlags bindingAttr) => t.GetMethods(bindingAttr);
        public Type GetNestedType(string name) => t.GetNestedType(name);
        public Type GetNestedType(string name, BindingFlags bindingAttr) => t.GetNestedType(name, bindingAttr);
        public Type[] GetNestedTypes() => t.GetNestedTypes();
        public Type[] GetNestedTypes(BindingFlags bindingAttr) => t.GetNestedTypes(bindingAttr);
        public PropertyInfo[] GetProperties() => t.GetProperties();
        public PropertyInfo[] GetProperties(BindingFlags bindingAttr) => t.GetProperties(bindingAttr);
        public PropertyInfo GetProperty(string name, Type[] types) => t.GetProperty(name, types);
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers) => t.GetProperty(name, returnType, types, modifiers);
        public PropertyInfo GetProperty(string name, Type returnType, Type[] types) => t.GetProperty(name, returnType, types);
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr) => t.GetProperty(name, bindingAttr);
        public PropertyInfo GetProperty(string name) => t.GetProperty(name);
        public PropertyInfo GetProperty(string name, Type returnType) => t.GetProperty(name, returnType);
        public bool IsAssignableFrom(Type c) => t.IsAssignableFrom(c);
        public bool IsAssignableFrom(TypeInfo typeInfo) => t.IsAssignableFrom(typeInfo.t);
        public bool IsEnumDefined(object value) => t.IsEnumDefined(value);
        public bool IsEquivalentTo(Type other) => t.IsEquivalentTo(other);
        public bool IsInstanceOfType(object o) => t.IsInstanceOfType(o);
        public bool IsSubclassOf(Type c) => t.IsSubclassOf(c);
        public Type MakeArrayType() => t.MakeArrayType();
        public Type MakeArrayType(int rank) => t.MakeArrayType(rank);
        public Type MakeByRefType() => t.MakeByRefType();
        public Type MakeGenericType(params Type[] typeArguments) => t.MakeGenericType(typeArguments);
        public Type MakePointerType() => t.MakePointerType();
    }


}

#endif
