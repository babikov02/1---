//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1С_Франчайзи_Вятка
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersSet
    {
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    
        public virtual AgentSet AgentSet { get; set; }
    }
}
