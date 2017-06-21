// Decompiled with JetBrains decompiler
// Type: VehicleControls.VehicleControls
// Assembly: vhcontrol.net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0D9421E2-B316-4052-B0BB-0425A56788FF
// Assembly location: C:\Users\rafik\Desktop\vehcontrol\vehiclecontrols.net.dll

using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace VehicleControls
{
  public class VehicleControls : BaseScript
  {
    private static string ERROR = "~r~Error: ";
    private static string ERROR_NOCAR = VehicleControls.VehicleControls.ERROR + "No tienes las llaves del vehiculo.";
    private Vehicle savedVehicle;

    public VehicleControls()
    {
      base.\u002Ector();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass13_0 cDisplayClass130 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass13_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass130.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass130.menuPool = new MenuPool();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass130.menu = new UIMenu("Menu Vehiculo", "");
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      cDisplayClass130.menuPool.Add(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      this.AddEngineItem(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      this.AddDoorLockItem(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      this.AddOpenDoorItem(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      this.AddLockSpeedItem(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      this.AddSaveVehicleItem(cDisplayClass130.menu);
      // ISSUE: reference to a compiler-generated field
      cDisplayClass130.menu.RefreshIndex();
      // ISSUE: method pointer
      this.add_Tick(new Func<Task>((object) cDisplayClass130, __methodptr(\u003C\u002Ector\u003Eb__0)));
    }

    private void AddEngineItem(UIMenu menu)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass3_0 cDisplayClass30 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass3_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass30.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass30.newItem = new UIMenuItem("Arrancar/Apagar el motor");
      // ISSUE: reference to a compiler-generated field
      menu.AddItem(cDisplayClass30.newItem);
      // ISSUE: method pointer
      menu.add_OnItemSelect(new ItemSelectEvent((object) cDisplayClass30, __methodptr(\u003CAddEngineItem\u003Eb__0)));
    }

    private void ToggleEngine(Vehicle car)
    {
      if (car.get_IsEngineRunning())
      {
        Screen.ShowNotification("Motor ~r~apagado~w~.", false);
        car.set_IsDriveable(false);
        car.set_IsEngineRunning(false);
      }
      else
      {
        Screen.ShowNotification("Motor ~g~encendido~w~.", false);
        car.set_IsDriveable(true);
        car.set_IsEngineRunning(true);
      }
    }

    private void AddDoorLockItem(UIMenu menu)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass5_0 cDisplayClass50 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass5_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass50.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass50.newItem = new UIMenuItem("Abrir/Cerrar las puertas", "NOTA: Esto te dara las llaves del coche.");
      // ISSUE: reference to a compiler-generated field
      menu.AddItem(cDisplayClass50.newItem);
      // ISSUE: method pointer
      menu.add_OnItemSelect(new ItemSelectEvent((object) cDisplayClass50, __methodptr(\u003CAddDoorLockItem\u003Eb__0)));
    }

    private void LockDoor(Vehicle car)
    {
      if (Function.Call<int>((Hash) 2719216112082266466L, new InputArgument[1]
      {
        InputArgument.op_Implicit((INativeValue) car)
      }) == 2)
      {
        Screen.ShowNotification("Puertas ~g~abiertas~w~.", false);
        Function.Call((Hash) -5304069180657533018L, new InputArgument[2]
        {
          InputArgument.op_Implicit((INativeValue) car),
          InputArgument.op_Implicit(0)
        });
      }
      else
      {
        Screen.ShowNotification("Puertas ~r~cerradas~w~.", false);
        Function.Call((Hash) -5304069180657533018L, new InputArgument[2]
        {
          InputArgument.op_Implicit((INativeValue) car),
          InputArgument.op_Implicit(2)
        });
      }
    }

    private void AddOpenDoorItem(UIMenu menu)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass7_0 cDisplayClass70 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass7_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass70.\u003C\u003E4__this = this;
      List<object> objectList = new List<object>()
      {
        (object) "Puerta delantera izquierda",
        (object) "Puerta delantera derecha",
        (object) " Puerta trasera izquierda",
        (object) " Puerta trasera derecha",
        (object) "Capo",
        (object) "maletero"
      };
      // ISSUE: reference to a compiler-generated field
      cDisplayClass70.newItem = new UIMenuListItem("Abrir/Cerrar", objectList, 0);
      // ISSUE: reference to a compiler-generated field
      menu.AddItem((UIMenuItem) cDisplayClass70.newItem);
      // ISSUE: method pointer
      menu.add_OnItemSelect(new ItemSelectEvent((object) cDisplayClass70, __methodptr(\u003CAddOpenDoorItem\u003Eb__0)));
    }

    private void ToggleDoor(Vehicle car, int index, string doorName)
    {
      if (Function.Call<bool>((Hash) -5124672078925642457L, new InputArgument[2]
      {
        InputArgument.op_Implicit((INativeValue) car),
        InputArgument.op_Implicit(index)
      }) != null)
        Screen.ShowNotification(VehicleControls.VehicleControls.ERROR + "Puerta destruida.", false);
      else if (Function.Call<float>((Hash) -126210560479777835L, new InputArgument[2]
      {
        InputArgument.op_Implicit((INativeValue) car),
        InputArgument.op_Implicit(index)
      }) == 0.0)
      {
        Screen.ShowNotification(doorName + " ~g~Abierto(a)~w~.", false);
        Function.Call((Hash) 8963811182594345058L, new InputArgument[4]
        {
          InputArgument.op_Implicit((INativeValue) car),
          InputArgument.op_Implicit(index),
          InputArgument.op_Implicit(false),
          InputArgument.op_Implicit(false)
        });
      }
      else
      {
        Screen.ShowNotification(doorName + " ~r~Cerrado(a)~w~.", false);
        Function.Call((Hash) -7792989666105914907L, new InputArgument[3]
        {
          InputArgument.op_Implicit((INativeValue) car),
          InputArgument.op_Implicit(index),
          InputArgument.op_Implicit(false)
        });
      }
    }

    private void AddLockSpeedItem(UIMenu menu)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass9_0 cDisplayClass90 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass9_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass90.\u003C\u003E4__this = this;
      List<object> objectList = new List<object>()
      {
        (object) "None"
      };
      int num = 30;
      while (num < 121)
      {
        objectList.Add((object) (num.ToString() + " KM/H"));
        num += 10;
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClass90.newItem = new UIMenuListItem("Limitador de velocidad", objectList, 0);
      // ISSUE: reference to a compiler-generated field
      menu.AddItem((UIMenuItem) cDisplayClass90.newItem);
      // ISSUE: method pointer
      menu.add_OnItemSelect(new ItemSelectEvent((object) cDisplayClass90, __methodptr(\u003CAddLockSpeedItem\u003Eb__0)));
    }

    private void LockSpeed(Vehicle car, UIMenuListItem item)
    {
      // ISSUE: reference to a compiler-generated field
      if (VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string[]>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string[]), typeof (VehicleControls.VehicleControls)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: variable of the null type
      __Null target = VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string[]>> p1 = VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__1;
      // ISSUE: reference to a compiler-generated field
      if (VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, char, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Split", (IEnumerable<Type>) null, typeof (VehicleControls.VehicleControls), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ((Func<CallSite, object, char, object>) VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__0.Target).Invoke((CallSite) VehicleControls.VehicleControls.\u003C\u003Eo__10.\u003C\u003Ep__0, item.IndexToItem(item.get_Index()), ' ');
      string[] strArray = ((Func<CallSite, object, string[]>) target).Invoke((CallSite) p1, obj);
      if (strArray[0] == "OFF")
      {
        ((Entity) car).set_MaxSpeed((float) int.MaxValue);
        Screen.ShowNotification("Limitador desactivado.", false);
      }
      else
      {
        float num = float.Parse(strArray[0]) / 3.6f;
        ((Entity) car).set_MaxSpeed(num);
        Screen.ShowNotification(string.Format("Limitador de velocidad a {0} {1}.", (object) strArray[0], (object) strArray[1]), false);
      }
    }

    private void AddSaveVehicleItem(UIMenu menu)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass11_0 cDisplayClass110 = new VehicleControls.VehicleControls.\u003C\u003Ec__DisplayClass11_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass110.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass110.newItem = new UIMenuItem("Recuperar las llaves del vehiculo");
      // ISSUE: reference to a compiler-generated field
      menu.AddItem(cDisplayClass110.newItem);
      // ISSUE: method pointer
      menu.add_OnItemSelect(new ItemSelectEvent((object) cDisplayClass110, __methodptr(\u003CAddSaveVehicleItem\u003Eb__0)));
    }

    private void SaveVehicle(Vehicle car)
    {
      this.savedVehicle = car;
    }
  }
}
