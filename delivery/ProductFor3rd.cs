public class Product
{
    public string Id { get; set; } // รหัสที่ mana ใช้
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public string Name { get; set; }
    public string Briefs { get; set; }
    public string PreviewImageId { get; set; } // mana จะมี api เอาไว้ดึงรูปโดยส่ง ImageId ไปถึงใช้ได้ ถ้า service อื่นดึงไปใช้ จะไม่ได้
    public IEnumerbale<string> ImageIds { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; } // รหัสที่ 3rd ใช้
    public List<string> Tags { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
// {ProductId:111, Name:ข้าวราดกะเพรา, Briefs:ข้าวสวยร้อนๆ ราดด้วยกะเพราแซบๆ, UnitPrice:{AmountUnit:40000}, ProductRef:111, Tags:[ "อาหารจานเดียว" ]}
// {ProductId:222, Name:อิตาเลียนโซดา, Briefs:อิตาเลียนโซดาหวานๆ, UnitPrice:{AmountUnit:40000}, ProductRef:222, Tags:[ "เครื่องดื่ม" ]}
// {ProductId:333, Name:เอสเพรสโซ่, Briefsเอสเพรสโซ่เข้มๆ:, UnitPrice:{AmountUnit:50000}, ProductRef:333, Tags:[ "กาแฟ" ]}

public class Product<TPref> : Product
{
    public TPref Preferences { get; set; } // Default preferences 
}
public class DefaultTypePreference { } // TPref

public class CurrencyAmount
{
    public long AmountUnit { get; set; } // สตางค์ * 1000 เช่น 250.50 บาท คือ AmountUnit:250500
    public string Currency { get; set; } // THB
}

public class ProductOption
{
    public string Id { get; set; }
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public List<string> Tags { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; } // None, Percent, OnTop, Replace
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
// {Tags:[ "อาหารจานเดียว" ], Name:ไก่, Value:Chicken, EffectOnProductPrice:None}
// {Tags:[ "อาหารจานเดียว" ], Name:หมู, Value:Pork, EffectOnProductPrice:None}
// {Tags:[ "อาหารจานเดียว" ], Name:เนื้อ, Value:Meat, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "อาหารจานเดียว" ], Name:กุ้ง, Value:Shrimp, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "อาหารจานเดียว" ], Name:ปลาหมึก, Value:Squid, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "อาหารจานเดียว" ], Name:ทะเล, Value:SeaFood, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "อาหารจานเดียว" ], Name:ไข่ดาว, Value:FriedEgg, UnitPrice:{AmountUnit:5000}, EffectOnProductPrice:OnTop}
// {Tags:[ "อาหารจานเดียว" ], Name:ไข่เจียว, Value:Omlet, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "เครื่องดื่ม" ], Name:หวานน้อย, Value:LessSweet, EffectOnProductPrice:None}
// {Tags:[ "เครื่องดื่ม" ], Name:หวานมาก, Value:MoreSweet, EffectOnProductPrice:None}
// {Tags:[ "เครื่องดื่ม" ], Name:ข้าวโพด, Value:Corn, UnitPrice:{AmountUnit:10000}, EffectOnProductPrice:OnTop}
// {Tags:[ "เครื่องดื่ม" ], Name:โอริโอ้, Value:Orio, UnitPrice:{AmountUnit:5000}, EffectOnProductPrice:OnTop}
// {Tags:[ "เครื่องดื่ม" ], Name:คอร์นเฟล็ก, Value:CornFlake, UnitPrice:{AmountUnit:15000}, EffectOnProductPrice:OnTop}
// {Tags:[ "กาแฟ" ], Name:XXX, Value:XXX, UnitPrice:{AmountUnit:XXX}, EffectOnProductPrice:XXX}
// {Tags:[ "กาแฟ" ], Name:XXX, Value:XXX, UnitPrice:{AmountUnit:XXX}, EffectOnProductPrice:XXX}
// {Tags:[ "กาแฟ" ], Name:XXX, Value:XXX, UnitPrice:{AmountUnit:XXX}, EffectOnProductPrice:XXX}
