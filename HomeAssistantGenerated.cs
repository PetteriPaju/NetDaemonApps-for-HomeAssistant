using System;
using System.Collections.Generic;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using NetDaemon.HassModel.Entities.Core;
using System.Text.Json.Serialization;

namespace HomeAssistantGenerated
{
	public interface IEntities
	{
		AutomationEntities Automation { get; }

		BinarySensorEntities BinarySensor { get; }

		ButtonEntities Button { get; }

		DeviceTrackerEntities DeviceTracker { get; }

		InputBooleanEntities InputBoolean { get; }

		InputDatetimeEntities InputDatetime { get; }

		InputNumberEntities InputNumber { get; }

		InputSelectEntities InputSelect { get; }

		InputTextEntities InputText { get; }

		LightEntities Light { get; }

		LockEntities Lock { get; }

		MediaPlayerEntities MediaPlayer { get; }

		NumberEntities Number { get; }

		PersistentNotificationEntities PersistentNotification { get; }

		PersonEntities Person { get; }

		SceneEntities Scene { get; }

		ScriptEntities Script { get; }

		SelectEntities Select { get; }

		SensorEntities Sensor { get; }

		SwitchEntities Switch { get; }

		UpdateEntities Update { get; }

		WeatherEntities Weather { get; }

		ZoneEntities Zone { get; }
	}

	public partial class Entities : IEntities
	{
		private readonly IHaContext _haContext;
		public Entities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AutomationEntities Automation => new(_haContext);
		public BinarySensorEntities BinarySensor => new(_haContext);
		public ButtonEntities Button => new(_haContext);
		public DeviceTrackerEntities DeviceTracker => new(_haContext);
		public InputBooleanEntities InputBoolean => new(_haContext);
		public InputDatetimeEntities InputDatetime => new(_haContext);
		public InputNumberEntities InputNumber => new(_haContext);
		public InputSelectEntities InputSelect => new(_haContext);
		public InputTextEntities InputText => new(_haContext);
		public LightEntities Light => new(_haContext);
		public LockEntities Lock => new(_haContext);
		public MediaPlayerEntities MediaPlayer => new(_haContext);
		public NumberEntities Number => new(_haContext);
		public PersistentNotificationEntities PersistentNotification => new(_haContext);
		public PersonEntities Person => new(_haContext);
		public SceneEntities Scene => new(_haContext);
		public ScriptEntities Script => new(_haContext);
		public SelectEntities Select => new(_haContext);
		public SensorEntities Sensor => new(_haContext);
		public SwitchEntities Switch => new(_haContext);
		public UpdateEntities Update => new(_haContext);
		public WeatherEntities Weather => new(_haContext);
		public ZoneEntities Zone => new(_haContext);
	}

	public partial class AutomationEntities
	{
		private readonly IHaContext _haContext;
		public AutomationEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Alarm Automation</summary>
		public AutomationEntity AlarmAutomation => new(_haContext, "automation.alarm_automation");
		///<summary>Alarm Automation (Duplicate)</summary>
		public AutomationEntity AlarmAutomationDuplicate => new(_haContext, "automation.alarm_automation_duplicate");
		///<summary>Alarm Toggle</summary>
		public AutomationEntity AlarmToggle => new(_haContext, "automation.alarm_toggle");
		///<summary>(AV)Switch to Cast-audio on TV State</summary>
		public AutomationEntity AudioSwitchCast => new(_haContext, "automation.audio_switch_cast");
		///<summary>Audio timeot</summary>
		public AutomationEntity AudioTimeot => new(_haContext, "automation.audio_timeot");
		///<summary>(AV) AudioUp</summary>
		public AutomationEntity AudiodownDuplicate => new(_haContext, "automation.audiodown_duplicate");
		///<summary>Auto Switch USB Switch IR</summary>
		public AutomationEntity AutoSwitchUsbSwitchIr => new(_haContext, "automation.auto_switch_usb_switch_ir");
		///<summary>Auto Turn off Bright light</summary>
		public AutomationEntity AutoTurnOffBrightLight => new(_haContext, "automation.auto_turn_off_bright_light");
		///<summary>Curtain Reminder</summary>
		public AutomationEntity Automation65 => new(_haContext, "automation.automation_65");
		///<summary>(AV) Automate Audio Switch with helper</summary>
		public AutomationEntity AvAutomateAudioSwitchWithHelper => new(_haContext, "automation.av_automate_audio_switch_with_helper");
		///<summary>(AV)On Audio Off</summary>
		public AutomationEntity AvOnAudioOff => new(_haContext, "automation.av_on_audio_off");
		///<summary>(AV)Turn Of AV When off home</summary>
		public AutomationEntity AvTurnOfAvWhenOffHome => new(_haContext, "automation.av_turn_of_av_when_off_home");
		///<summary>Away From Home</summary>
		public AutomationEntity AwayFromHome => new(_haContext, "automation.away_from_home");
		///<summary>AwokeTime Helper</summary>
		public AutomationEntity AwoketimeHelper => new(_haContext, "automation.awoketime_helper");
		///<summary>BedLightToOnMainLightOff</summary>
		public AutomationEntity Bedlighttoonmainlightoff => new(_haContext, "automation.bedlighttoonmainlightoff");
		///<summary>Break Notification</summary>
		public AutomationEntity BreakNotification => new(_haContext, "automation.break_notification");
		///<summary>Bright Light Automation</summary>
		public AutomationEntity BrightLightAutomation => new(_haContext, "automation.bright_light_automation");
		///<summary>Chargers toggle Notification</summary>
		public AutomationEntity ChargersToggleNotification => new(_haContext, "automation.chargers_toggle_notification");
		///<summary>Energy Calcluations</summary>
		public AutomationEntity EnergyCalcluations => new(_haContext, "automation.energy_calcluations");
		///<summary>Energy Price Update alarm</summary>
		public AutomationEntity EnergyPriceUpdateAlarm => new(_haContext, "automation.energy_price_update_alarm");
		///<summary>(Example) Send Audio Noification</summary>
		public AutomationEntity ExampleSendAudioNoification => new(_haContext, "automation.example_send_audio_noification");
		///<summary>Fan auto off</summary>
		public AutomationEntity FanAutoOff => new(_haContext, "automation.fan_auto_off");
		///<summary>Freezer temp calibration</summary>
		public AutomationEntity FreezerTempCalibration => new(_haContext, "automation.freezer_temp_calibration");
		///<summary>Front Door Sensori automation</summary>
		public AutomationEntity FrontDoorSensoriAutomation => new(_haContext, "automation.front_door_sensori_automation");
		///<summary>(Guest) Guest Mode Notification</summary>
		public AutomationEntity GuestModeNotification => new(_haContext, "automation.guest_mode_notification");
		///<summary>Hallway off on toilet entry</summary>
		public AutomationEntity HallwayOffOnToiletEntry => new(_haContext, "automation.hallway_off_on_toilet_entry");
		///<summary>(Hue Swich) Bed Switch</summary>
		public AutomationEntity HueSwichBedSwitch => new(_haContext, "automation.hue_swich_bed_switch");
		///<summary>(hue switch)main light off </summary>
		public AutomationEntity HueSwitchMainLightOff => new(_haContext, "automation.hue_switch_main_light_off");
		///<summary>Hydration check</summary>
		public AutomationEntity HydrationCheck => new(_haContext, "automation.hydration_check");
		///<summary>Is Home failsafe</summary>
		public AutomationEntity IsHomeFailsafe => new(_haContext, "automation.is_home_failsafe");
		///<summary>IsAsleep-Actions</summary>
		public AutomationEntity IsasleepActions => new(_haContext, "automation.isasleep_actions");
		///<summary>IsAsleepOffUpdate</summary>
		public AutomationEntity Isasleepoffupdate => new(_haContext, "automation.isasleepoffupdate");
		///<summary>IsAsleepOnUpdate</summary>
		public AutomationEntity Isasleepupdate => new(_haContext, "automation.isasleepupdate");
		///<summary>(Sensor) Kitchen Light Automation</summary>
		public AutomationEntity KitchenLightAutomationDuplicate => new(_haContext, "automation.kitchen_light_automation_duplicate");
		///<summary>Konofan alert</summary>
		public AutomationEntity KonofanAlert => new(_haContext, "automation.konofan_alert");
		///<summary>Laptop Charging Atuomation</summary>
		public AutomationEntity LaptopChargingAtuomation => new(_haContext, "automation.laptop_charging_atuomation");
		///<summary>(Phone)Low Battery Alert</summary>
		public AutomationEntity LowBatteryAlert => new(_haContext, "automation.low_battery_alert");
		///<summary>Main light on bed light off</summary>
		public AutomationEntity MainLightOnBedLightOff => new(_haContext, "automation.main_light_on_bed_light_off");
		///<summary>Media Playing Update</summary>
		public AutomationEntity MediaPlayingUpdate => new(_haContext, "automation.media_playing_update");
		///<summary>(PC) Low Memory Alert</summary>
		public AutomationEntity MemoryAlert => new(_haContext, "automation.memory_alert");
		///<summary>(AV/PC)Manage AV Audio when Audio device changes</summary>
		public AutomationEntity NewAutomation => new(_haContext, "automation.new_automation");
		///<summary>(AV) AudioDown</summary>
		public AutomationEntity NewAutomation2 => new(_haContext, "automation.new_automation_2");
		///<summary>Cube-Functions</summary>
		public AutomationEntity NewAutomation4 => new(_haContext, "automation.new_automation_4");
		///<summary>(Notifications) Can Send Audio Notification Update</summary>
		public AutomationEntity NotificationsCanSendAudioNotificationUpdate => new(_haContext, "automation.notifications_can_send_audio_notification_update");
		///<summary>Outside temparature calibration</summary>
		public AutomationEntity OutsideTemparatureCalibration => new(_haContext, "automation.outside_temparature_calibration");
		///<summary>(AV/PC) Switch To PC Audio when Power in on</summary>
		public AutomationEntity PcAudioSwitch => new(_haContext, "automation.pc_audio_switch");
		///<summary>(PC) PC Accessories Auto On/Off</summary>
		public AutomationEntity PcAutoOn => new(_haContext, "automation.pc_auto_on");
		///<summary>(PC) Brightness Reset</summary>
		public AutomationEntity PcBrigtnessReset => new(_haContext, "automation.pc_brigtness_reset");
		///<summary>(PC) Pc off on low power</summary>
		public AutomationEntity PcPcOffOnLowPower => new(_haContext, "automation.pc_pc_off_on_low_power");
		///<summary>(Sensor) PC Sensor Automation</summary>
		public AutomationEntity PcSensorAutomation => new(_haContext, "automation.pc_sensor_automation");
		///<summary>Pesukone</summary>
		public AutomationEntity Pesukone => new(_haContext, "automation.pesukone");
		///<summary>(Phone/AV) Phone Audio Connect</summary>
		public AutomationEntity PhoneCensorTest => new(_haContext, "automation.phone_censor_test");
		///<summary>Schedule PC Shutdown</summary>
		public AutomationEntity SchedulePcShutdown => new(_haContext, "automation.schedule_pc_shutdown");
		///<summary>(Sensor) Bedside Sensor</summary>
		public AutomationEntity SensorBedsideSensor => new(_haContext, "automation.sensor_bedside_sensor");
		///<summary>(Sensor) Hallway Light</summary>
		public AutomationEntity SensorHallwayLight => new(_haContext, "automation.sensor_hallway_light");
		///<summary>(Sensor) Storage Light</summary>
		public AutomationEntity SensorStorageLight => new(_haContext, "automation.sensor_storage_light");
		///<summary>(Sensor)  Toilet Light Automation Off</summary>
		public AutomationEntity SensorToiletLightAutomationOff => new(_haContext, "automation.sensor_toilet_light_automation_off");
		///<summary>Sensors Active Notification</summary>
		public AutomationEntity SensorsActiveNotification => new(_haContext, "automation.sensors_active_notification");
		///<summary>Steps Parse</summary>
		public AutomationEntity StepsParse => new(_haContext, "automation.steps_parse");
		///<summary>Homecoming</summary>
		public AutomationEntity Test => new(_haContext, "automation.test");
		///<summary>(Sensor)  Toilet Light Automation On</summary>
		public AutomationEntity ToiletLightAutomation => new(_haContext, "automation.toilet_light_automation");
		///<summary>(AV/Phone) Turn audio off when phone jack disconnects</summary>
		public AutomationEntity TurnAudioOffWhenPhoneJackDisconnects => new(_haContext, "automation.turn_audio_off_when_phone_jack_disconnects");
		///<summary>Turn off light when in toilet</summary>
		public AutomationEntity TurnOffLightWhenInToilet => new(_haContext, "automation.turn_off_light_when_in_toilet");
		///<summary>Turn off Pc when Lora training done</summary>
		public AutomationEntity TurnOffPcWhenLoraTrainingDone => new(_haContext, "automation.turn_off_pc_when_lora_training_done");
		///<summary>TV-Chromecast-PowerSynch</summary>
		public AutomationEntity TvChromecastPowersynch => new(_haContext, "automation.tv_chromecast_powersynch");
	}

	public partial class BinarySensorEntities
	{
		private readonly IHaContext _haContext;
		public BinarySensorEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>PC Sensor occupancy</summary>
		public BinarySensorEntity E0x001788010bcfb16fOccupancy => new(_haContext, "binary_sensor.0x001788010bcfb16f_occupancy");
		///<summary>PC Sensor update available</summary>
		public BinarySensorEntity E0x001788010bcfb16fUpdateAvailable => new(_haContext, "binary_sensor.0x001788010bcfb16f_update_available");
		///<summary>Back Corner Plug update available</summary>
		public BinarySensorEntity BackCornerPlugUpdateAvailable => new(_haContext, "binary_sensor.back_corner_plug_update_available");
		///<summary>Bed Light update available</summary>
		public BinarySensorEntity BedLightUpdateAvailable => new(_haContext, "binary_sensor.bed_light_update_available");
		///<summary>Bed Light Plug update available</summary>
		public BinarySensorEntity BrightLightPlugUpdateAvailable => new(_haContext, "binary_sensor.bright_light_plug_update_available");
		///<summary>Desktop Light update available</summary>
		public BinarySensorEntity DesktopLightUpdateAvailable => new(_haContext, "binary_sensor.desktop_light_update_available");
		///<summary>Fan Plug update available</summary>
		public BinarySensorEntity FanPlugUpdateAvailable => new(_haContext, "binary_sensor.fan_plug_update_available");
		///<summary>Front-Door Sensor contact</summary>
		public BinarySensorEntity FrontDoorSensorContact => new(_haContext, "binary_sensor.front_door_sensor_contact");
		///<summary>Hallway Light update available</summary>
		public BinarySensorEntity HallwayLightUpdateAvailable => new(_haContext, "binary_sensor.hallway_light_update_available");
		///<summary>Hallway Sensor occupancy</summary>
		public BinarySensorEntity HallwaySensorOccupancy => new(_haContext, "binary_sensor.hallway_sensor_occupancy");
		///<summary>Hallway Sensor update available</summary>
		public BinarySensorEntity HallwaySensorUpdateAvailable => new(_haContext, "binary_sensor.hallway_sensor_update_available");
		///<summary>Home occupancy sensors</summary>
		public BinarySensorEntity HomeOccupancySensors => new(_haContext, "binary_sensor.home_occupancy_sensors");
		///<summary>Hue Switch Bed update available</summary>
		public BinarySensorEntity HueSwitchBedUpdateAvailable => new(_haContext, "binary_sensor.hue_switch_bed_update_available");
		///<summary>Hue Switch Living Room update available</summary>
		public BinarySensorEntity HueSwitchLivingRoomUpdateAvailable => new(_haContext, "binary_sensor.hue_switch_living_room_update_available");
		///<summary>Kitchen Light update available</summary>
		public BinarySensorEntity KitchenLightUpdateAvailable => new(_haContext, "binary_sensor.kitchen_light_update_available");
		///<summary>Kitchen Sensor occupancy</summary>
		public BinarySensorEntity KitchenSensorOccupancy => new(_haContext, "binary_sensor.kitchen_sensor_occupancy");
		///<summary>Kitchen Sensor update available</summary>
		public BinarySensorEntity KitchenSensorUpdateAvailable => new(_haContext, "binary_sensor.kitchen_sensor_update_available");
		///<summary>Living Room Light update available</summary>
		public BinarySensorEntity LivingRoomLightUpdateAvailable => new(_haContext, "binary_sensor.living_room_light_update_available");
		///<summary>moto g(8) power lite Headphones</summary>
		public BinarySensorEntity MotoG8PowerLiteHeadphones => new(_haContext, "binary_sensor.moto_g_8_power_lite_headphones");
		///<summary>moto g(8) power lite Is Charging</summary>
		public BinarySensorEntity MotoG8PowerLiteIsCharging => new(_haContext, "binary_sensor.moto_g_8_power_lite_is_charging");
		///<summary>Open Curtain Limit</summary>
		public BinarySensorEntity OpenCurtainLimit => new(_haContext, "binary_sensor.open_curtain_limit");
		///<summary>PC-Plug update available</summary>
		public BinarySensorEntity PcPlugUpdateAvailable => new(_haContext, "binary_sensor.pc_plug_update_available");
		///<summary>Portable headphone sensors</summary>
		public BinarySensorEntity PortableHeadphoneSensors => new(_haContext, "binary_sensor.portable_headphone_sensors");
		///<summary>Power Meter (General) update available</summary>
		public BinarySensorEntity PowerMeterGeneralUpdateAvailable => new(_haContext, "binary_sensor.power_meter_general_update_available");
		///<summary>PC-Acc&Fridge Power Meter update available</summary>
		public BinarySensorEntity PowerMeterPlugUpdateAvailable => new(_haContext, "binary_sensor.power_meter_plug_update_available");
		///<summary>Kitchen Power Meter-Plug update available</summary>
		public BinarySensorEntity RefrigeratorPlugUpdateAvailable => new(_haContext, "binary_sensor.refrigerator_plug_update_available");
		///<summary>Remote UI</summary>
		public BinarySensorEntity RemoteUi => new(_haContext, "binary_sensor.remote_ui");
		///<summary>Runner Plug update available</summary>
		public BinarySensorEntity RunnerPlugUpdateAvailable => new(_haContext, "binary_sensor.runner_plug_update_available");
		///<summary>SM-T530 Headphones</summary>
		public BinarySensorEntity SmT530Headphones => new(_haContext, "binary_sensor.sm_t530_headphones");
		///<summary>SM-T530 Is Charging</summary>
		public BinarySensorEntity SmT530IsCharging => new(_haContext, "binary_sensor.sm_t530_is_charging");
		///<summary>SM-T530 Music Active</summary>
		public BinarySensorEntity SmT530MusicActive => new(_haContext, "binary_sensor.sm_t530_music_active");
		///<summary>Storage Light update available</summary>
		public BinarySensorEntity StorageLightUpdateAvailable => new(_haContext, "binary_sensor.storage_light_update_available");
		///<summary>Storage Sensor occupancy</summary>
		public BinarySensorEntity StorageSensorAqaraOccupancy => new(_haContext, "binary_sensor.storage_sensor_aqara_occupancy");
		///<summary>Toilet Light_1_update_available</summary>
		public BinarySensorEntity ToiletLight1UpdateAvailable => new(_haContext, "binary_sensor.toilet_light_1_update_available");
		///<summary>Toilet Seat Sensor contact</summary>
		public BinarySensorEntity ToiletSeatSensorContact => new(_haContext, "binary_sensor.toilet_seat_sensor_contact");
		///<summary>Toilet Sensor occupancy</summary>
		public BinarySensorEntity ToiletSensorOccupancy => new(_haContext, "binary_sensor.toilet_sensor_occupancy");
		///<summary>Toilet Sensor update available</summary>
		public BinarySensorEntity ToiletSensorUpdateAvailable => new(_haContext, "binary_sensor.toilet_sensor_update_available");
		///<summary>Tv Power Meter update available</summary>
		public BinarySensorEntity TvPowerMeterUpdateAvailable => new(_haContext, "binary_sensor.tv_power_meter_update_available");
	}

	public partial class ButtonEntities
	{
		private readonly IHaContext _haContext;
		public ButtonEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>ENVY_TurnOffMonitors</summary>
		public ButtonEntity EnvyTurnoffmonitors => new(_haContext, "button.envy_turnoffmonitors");
		///<summary>ENVY_WakeKey</summary>
		public ButtonEntity EnvyWakekey => new(_haContext, "button.envy_wakekey");
		///<summary>PC-ResetBrigtness</summary>
		public ButtonEntity PcResetbrigtness => new(_haContext, "button.pc_resetbrigtness");
		///<summary>PC Shutdown</summary>
		public ButtonEntity PcShutdown => new(_haContext, "button.pc_shutdown");
		///<summary>PC_ShutDownCancel</summary>
		public ButtonEntity PcShutdowncancel => new(_haContext, "button.pc_shutdowncancel");
		///<summary>PC_TurnOffMonitors</summary>
		public ButtonEntity PcTurnoffmonitors => new(_haContext, "button.pc_turnoffmonitors");
		///<summary>PC_WakeKey</summary>
		public ButtonEntity PcWakekey => new(_haContext, "button.pc_wakekey");
		///<summary>Synchronize Devices</summary>
		public ButtonEntity SynchronizeDevices => new(_haContext, "button.synchronize_devices");
	}

	public partial class DeviceTrackerEntities
	{
		private readonly IHaContext _haContext;
		public DeviceTrackerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>moto g(8) power lite</summary>
		public DeviceTrackerEntity MotoG8PowerLite => new(_haContext, "device_tracker.moto_g_8_power_lite");
		///<summary>SM-T530</summary>
		public DeviceTrackerEntity SmT530 => new(_haContext, "device_tracker.sm_t530");
	}

	public partial class InputBooleanEntities
	{
		private readonly IHaContext _haContext;
		public InputBooleanEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Alarm Enabled</summary>
		public InputBooleanEntity Alarmenabled => new(_haContext, "input_boolean.alarmenabled");
		///<summary>Allow Kitchen Light Turn Off</summary>
		public InputBooleanEntity AllowKitchenLightTurnOff => new(_haContext, "input_boolean.allow_kitchen_light_turn_off");
		///<summary>Auto Turn Off Server</summary>
		public InputBooleanEntity AutoTurnOffServer => new(_haContext, "input_boolean.auto_turn_off_server");
		///<summary>Guest Mode</summary>
		public InputBooleanEntity GuestMode => new(_haContext, "input_boolean.guest_mode");
		///<summary>Hydration Check Active</summary>
		public InputBooleanEntity HydrationCheckActive => new(_haContext, "input_boolean.hydration_check_active");
		///<summary>IsAsleep</summary>
		public InputBooleanEntity Isasleep => new(_haContext, "input_boolean.isasleep");
		///<summary>IsHome</summary>
		public InputBooleanEntity Ishome => new(_haContext, "input_boolean.ishome");
		///<summary>Media Playing</summary>
		public InputBooleanEntity MediaPlaying => new(_haContext, "input_boolean.media_playing");
		///<summary>netdaemon_hass_model_hello_world_app</summary>
		public InputBooleanEntity NetdaemonHassModelHelloWorldApp => new(_haContext, "input_boolean.netdaemon_hass_model_hello_world_app");
		///<summary>netdaemon_hass_model_light_on_movement</summary>
		public InputBooleanEntity NetdaemonHassModelLightOnMovement => new(_haContext, "input_boolean.netdaemon_hass_model_light_on_movement");
		///<summary>Sensors Active</summary>
		public InputBooleanEntity SensorsActive => new(_haContext, "input_boolean.sensors_active");
		///<summary>Should Send Audio Notifications</summary>
		public InputBooleanEntity ShouldSendAudioNotifications => new(_haContext, "input_boolean.should_send_audio_notifications");
	}

	public partial class InputDatetimeEntities
	{
		private readonly IHaContext _haContext;
		public InputDatetimeEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>AlarmTime</summary>
		public InputDatetimeEntity Alarmtime => new(_haContext, "input_datetime.alarmtime");
		///<summary>(AV) TimeOfLastVolume</summary>
		public InputDatetimeEntity AvTimeoflastvolume => new(_haContext, "input_datetime.av_timeoflastvolume");
		///<summary>AwokeTime</summary>
		public InputDatetimeEntity Awoketime => new(_haContext, "input_datetime.awoketime");
		///<summary>Charger off time</summary>
		public InputDatetimeEntity ChargerOffTime => new(_haContext, "input_datetime.charger_off_time");
		///<summary>Chargers On Time</summary>
		public InputDatetimeEntity ChargersOnTime => new(_haContext, "input_datetime.chargers_on_time");
		///<summary>IsAsleepTimeHelper</summary>
		public InputDatetimeEntity Isasleephelper1 => new(_haContext, "input_datetime.isasleephelper1");
		///<summary>LastIsAsleepTime</summary>
		public InputDatetimeEntity Lastisasleeptime => new(_haContext, "input_datetime.lastisasleeptime");
		///<summary>SleepStartTime</summary>
		public InputDatetimeEntity Sleepstarttime => new(_haContext, "input_datetime.sleepstarttime");
	}

	public partial class InputNumberEntities
	{
		private readonly IHaContext _haContext;
		public InputNumberEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>AV-CurrentVolume</summary>
		public InputNumberEntity AvCurrentvolume => new(_haContext, "input_number.av_currentvolume");
		///<summary>(AV)LastVolumeHelper</summary>
		public InputNumberEntity AvLastvolumehelper => new(_haContext, "input_number.av_lastvolumehelper");
		///<summary>Combined PC Energy + Fridge</summary>
		public InputNumberEntity CombinedPcEnergy => new(_haContext, "input_number.combined_pc_energy");
		///<summary>DailySteps</summary>
		public InputNumberEntity Dailysteps => new(_haContext, "input_number.dailysteps");
		///<summary>Energy Cost Daily</summary>
		public InputNumberEntity EnergyCostDaily => new(_haContext, "input_number.energy_cost_daily");
		///<summary>Energy Cost Hourly</summary>
		public InputNumberEntity EnergyCostHourly => new(_haContext, "input_number.energy_cost_hourly");
		///<summary>Energy_Fortum_ALV</summary>
		public InputNumberEntity EnergyFortumAlv => new(_haContext, "input_number.energy_fortum_alv");
		///<summary>Energy_Fortum_Hard_cost</summary>
		public InputNumberEntity EnergyFortumHardCost => new(_haContext, "input_number.energy_fortum_hard_cost");
		///<summary>Energy_Transfer_ALV</summary>
		public InputNumberEntity EnergyTransferAlv => new(_haContext, "input_number.energy_transfer_alv");
		///<summary>Energy_Transfer_cost</summary>
		public InputNumberEntity EnergyTransferCost => new(_haContext, "input_number.energy_transfer_cost");
		///<summary>Fridge Real Temp</summary>
		public InputNumberEntity FridgeRealTemp => new(_haContext, "input_number.fridge_real_temp");
		///<summary>Sensor Luminance Threshold</summary>
		public InputNumberEntity SensorLuminanceThreshold => new(_haContext, "input_number.sensor_luminance_threshold");
		///<summary>Temparature Outside Calibrated</summary>
		public InputNumberEntity TemparatureOutsideCalibrated => new(_haContext, "input_number.temparature_outside_calibrated");
		///<summary>Total Daily Energy</summary>
		public InputNumberEntity TotalDailyEnergy => new(_haContext, "input_number.total_daily_energy");
	}

	public partial class InputSelectEntities
	{
		private readonly IHaContext _haContext;
		public InputSelectEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>AtLoraEnded</summary>
		public InputSelectEntity Atloraended => new(_haContext, "input_select.atloraended");
		///<summary>Current AV Audio</summary>
		public InputSelectEntity CurrentAvAudio => new(_haContext, "input_select.current_av_audio");
	}

	public partial class InputTextEntities
	{
		private readonly IHaContext _haContext;
		public InputTextEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>AsleepTime0Remover</summary>
		public InputTextEntity Asleeptime0remover => new(_haContext, "input_text.asleeptime0remover");
		///<summary>LastOnLight</summary>
		public InputTextEntity Lastonlight => new(_haContext, "input_text.lastonlight");
	}

	public partial class LightEntities
	{
		private readonly IHaContext _haContext;
		public LightEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>All Lights</summary>
		public LightEntity AllLights => new(_haContext, "light.all_lights");
		///<summary>Bed Light</summary>
		public LightEntity BedLight => new(_haContext, "light.bed_light");
		///<summary>Desktop Light</summary>
		public LightEntity DesktopLight => new(_haContext, "light.desktop_light");
		///<summary>Hallway Light</summary>
		public LightEntity HallwayLight => new(_haContext, "light.hallway_light");
		///<summary>Kitchen Light</summary>
		public LightEntity KitchenLight2 => new(_haContext, "light.kitchen_light_2");
		///<summary>Living Room Light</summary>
		public LightEntity LivingRoomLight => new(_haContext, "light.living_room_light");
		///<summary>Living Room Lights</summary>
		public LightEntity LivingRoomLights => new(_haContext, "light.living_room_lights");
		///<summary>Multi Plug: Bright Light</summary>
		public LightEntity MultiPlugBrightLight => new(_haContext, "light.multi_plug_bright_light");
		///<summary>Storage Light</summary>
		public LightEntity StorageLight2 => new(_haContext, "light.storage_light_2");
		///<summary>Toilet Light_1</summary>
		public LightEntity ToiletLight1 => new(_haContext, "light.toilet_light_1");
	}

	public partial class LockEntities
	{
		private readonly IHaContext _haContext;
		public LockEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Back Corner Plug child lock</summary>
		public LockEntity BackCornerPlugChildLock => new(_haContext, "lock.back_corner_plug_child_lock");
		///<summary>PC-Plug child lock</summary>
		public LockEntity PcPlugChildLock => new(_haContext, "lock.pc_plug_child_lock");
		///<summary>Power Meter (General) child lock</summary>
		public LockEntity PowerMeterGeneralChildLock => new(_haContext, "lock.power_meter_general_child_lock");
		///<summary>PC-Acc&Fridge Power Meter child lock</summary>
		public LockEntity PowerMeterPlugChildLock => new(_haContext, "lock.power_meter_plug_child_lock");
		///<summary>Kitchen Power Meter-Plug child lock</summary>
		public LockEntity RefrigeratorPlugChildLock => new(_haContext, "lock.refrigerator_plug_child_lock");
		///<summary>Tv Power Meter child lock</summary>
		public LockEntity TvPowerMeterChildLock => new(_haContext, "lock.tv_power_meter_child_lock");
	}

	public partial class MediaPlayerEntities
	{
		private readonly IHaContext _haContext;
		public MediaPlayerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Android TV 192.168.0.20</summary>
		public MediaPlayerEntity AndroidTv192168020 => new(_haContext, "media_player.android_tv_192_168_0_20");
		///<summary>ENVY</summary>
		public MediaPlayerEntity Envy => new(_haContext, "media_player.envy");
		public MediaPlayerEntity LivingRoomDisplay => new(_haContext, "media_player.living_room_display");
		public MediaPlayerEntity LivingRoomTv => new(_haContext, "media_player.living_room_tv");
		public MediaPlayerEntity OlohuoneNest => new(_haContext, "media_player.olohuone_nest");
		///<summary>PC</summary>
		public MediaPlayerEntity Pc => new(_haContext, "media_player.pc");
		///<summary>VLC-TELNET</summary>
		public MediaPlayerEntity VlcTelnet => new(_haContext, "media_player.vlc_telnet");
	}

	public partial class NumberEntities
	{
		private readonly IHaContext _haContext;
		public NumberEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>PC Sensor occupancy timeout</summary>
		public NumberEntity E0x001788010bcfb16fOccupancyTimeout => new(_haContext, "number.0x001788010bcfb16f_occupancy_timeout");
		///<summary>Hallway Sensor occupancy timeout</summary>
		public NumberEntity HallwaySensorOccupancyTimeout => new(_haContext, "number.hallway_sensor_occupancy_timeout");
		///<summary>Kitchen Sensor occupancy timeout</summary>
		public NumberEntity KitchenSensorOccupancyTimeout => new(_haContext, "number.kitchen_sensor_occupancy_timeout");
		///<summary>Toilet Sensor occupancy timeout</summary>
		public NumberEntity ToiletSensorOccupancyTimeout => new(_haContext, "number.toilet_sensor_occupancy_timeout");
	}

	public partial class PersistentNotificationEntities
	{
		private readonly IHaContext _haContext;
		public PersistentNotificationEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Hello world!</summary>
		public PersistentNotificationEntity Notification => new(_haContext, "persistent_notification.notification");
	}

	public partial class PersonEntities
	{
		private readonly IHaContext _haContext;
		public PersonEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Petteri</summary>
		public PersonEntity Petteri => new(_haContext, "person.petteri");
	}

	public partial class SceneEntities
	{
		private readonly IHaContext _haContext;
		public SceneEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>-Active Audio- Game</summary>
		public SceneEntity ActiveAudioGame => new(_haContext, "scene.active_audio_game");
		///<summary>-Active Audio-  OFF</summary>
		public SceneEntity ActiveAudioOff => new(_haContext, "scene.active_audio_off");
		///<summary>-Active Audio- Portable</summary>
		public SceneEntity ActiveAudioPortable => new(_haContext, "scene.active_audio_portable");
		///<summary>CurrentElecticityPriceReadout</summary>
		public SceneEntity Currentelecticitypricereadout => new(_haContext, "scene.currentelecticitypricereadout");
		///<summary>"Fridge Sensor":Switch:On</summary>
		public SceneEntity FridgeSensorSwitchOn => new(_haContext, "scene.fridge_sensor_switch_on");
		///<summary>Out of home state</summary>
		public SceneEntity OutOfHomeState => new(_haContext, "scene.out_of_home_state");
		///<summary>-Active Audio- PC</summary>
		public SceneEntity PcAudioActive => new(_haContext, "scene.pc_audio_active");
		///<summary>PC ON AUTO</summary>
		public SceneEntity PcOnAuto => new(_haContext, "scene.pc_on_auto");
		///<summary>Read Out Awake Time</summary>
		public SceneEntity ReadOutAwakeTime => new(_haContext, "scene.read_out_awake_time");
		///<summary>Switch USB Laptop</summary>
		public SceneEntity SwitchUsbLaptop => new(_haContext, "scene.switch_usb_laptop");
		///<summary>Switch USB PC</summary>
		public SceneEntity SwitchUsbPc => new(_haContext, "scene.switch_usb_pc");
		///<summary>-Active Audio-  TV</summary>
		public SceneEntity TvAudioActive => new(_haContext, "scene.tv_audio_active");
	}

	public partial class ScriptEntities
	{
		private readonly IHaContext _haContext;
		public ScriptEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>(Script)AV Audio Off </summary>
		public ScriptEntity E1659477669028 => new(_haContext, "script.1659477669028");
		///<summary>AV - Volume - Down</summary>
		public ScriptEntity AvVolumeDown => new(_haContext, "script.av_volume_down");
		///<summary>AV - Volume - Up</summary>
		public ScriptEntity AvVolumeUp => new(_haContext, "script.av_volume_up");
		///<summary>Send Audio Notification</summary>
		public ScriptEntity NotifyPushover => new(_haContext, "script.notify_pushover");
		///<summary>(PC)Cancel_Shut_Down</summary>
		public ScriptEntity PccancelShutDown => new(_haContext, "script.pccancel_shut_down");
		///<summary>(PC)Turn Off PC</summary>
		public ScriptEntity PcturnOffPc => new(_haContext, "script.pcturn_off_pc");
		///<summary>Read Out Electricity Price</summary>
		public ScriptEntity ReadOutElectricityPrice => new(_haContext, "script.read_out_electricity_price");
		///<summary>Readout LastTime Awoken</summary>
		public ScriptEntity ReadoutLasttimeAwoken => new(_haContext, "script.readout_lasttime_awoken");
		///<summary>Send Audio Notification TTS</summary>
		public ScriptEntity SendAudioNotification => new(_haContext, "script.send_audio_notification");
		///<summary>Send Audio Notification File</summary>
		public ScriptEntity SendAudioNotificationFile => new(_haContext, "script.send_audio_notification_file");
		///<summary>Turn Off Server</summary>
		public ScriptEntity TurnOffServer => new(_haContext, "script.turn_off_server");
		///<summary>Turn On Server</summary>
		public ScriptEntity TurnOnServer => new(_haContext, "script.turn_on_server");
	}

	public partial class SelectEntities
	{
		private readonly IHaContext _haContext;
		public SelectEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>PC Sensor motion sensitivity</summary>
		public SelectEntity E0x001788010bcfb16fMotionSensitivity => new(_haContext, "select.0x001788010bcfb16f_motion_sensitivity");
		///<summary>Back Corner Plug indicator mode</summary>
		public SelectEntity BackCornerPlugIndicatorMode => new(_haContext, "select.back_corner_plug_indicator_mode");
		///<summary>Back Corner Plug power outage memory</summary>
		public SelectEntity BackCornerPlugPowerOutageMemory => new(_haContext, "select.back_corner_plug_power_outage_memory");
		///<summary>Bed Light power on behavior</summary>
		public SelectEntity BedLightPowerOnBehavior => new(_haContext, "select.bed_light_power_on_behavior");
		///<summary>Bed-Multi-Plug power on behavior</summary>
		public SelectEntity BedMultiPlugPowerOnBehavior => new(_haContext, "select.bed_multi_plug_power_on_behavior");
		///<summary>Desktop Light power on behavior</summary>
		public SelectEntity DesktopLightPowerOnBehavior => new(_haContext, "select.desktop_light_power_on_behavior");
		///<summary>Hallway Light power on behavior</summary>
		public SelectEntity HallwayLightPowerOnBehavior => new(_haContext, "select.hallway_light_power_on_behavior");
		///<summary>Hallway Sensor motion sensitivity</summary>
		public SelectEntity HallwaySensorMotionSensitivity => new(_haContext, "select.hallway_sensor_motion_sensitivity");
		///<summary>Kitchen Light power on behavior</summary>
		public SelectEntity KitchenLightPowerOnBehavior => new(_haContext, "select.kitchen_light_power_on_behavior");
		///<summary>Kitchen Sensor motion sensitivity</summary>
		public SelectEntity KitchenSensorMotionSensitivity => new(_haContext, "select.kitchen_sensor_motion_sensitivity");
		///<summary>Living Room Light power on behavior</summary>
		public SelectEntity LivingRoomLightPowerOnBehavior => new(_haContext, "select.living_room_light_power_on_behavior");
		///<summary>PC Connector Indicator light mode</summary>
		public SelectEntity PcConnectorIndicatorLightMode => new(_haContext, "select.pc_connector_indicator_light_mode");
		///<summary>PC Connector Power on behavior</summary>
		public SelectEntity PcConnectorPowerOnBehavior => new(_haContext, "select.pc_connector_power_on_behavior");
		///<summary>PC-Plug indicator mode</summary>
		public SelectEntity PcPlugIndicatorMode => new(_haContext, "select.pc_plug_indicator_mode");
		///<summary>PC-Plug power outage memory</summary>
		public SelectEntity PcPlugPowerOutageMemory => new(_haContext, "select.pc_plug_power_outage_memory");
		///<summary>Power Meter (General) indicator mode</summary>
		public SelectEntity PowerMeterGeneralIndicatorMode => new(_haContext, "select.power_meter_general_indicator_mode");
		///<summary>Power Meter (General) power outage memory</summary>
		public SelectEntity PowerMeterGeneralPowerOutageMemory => new(_haContext, "select.power_meter_general_power_outage_memory");
		///<summary>PC-Acc&Fridge Power Meter indicator mode</summary>
		public SelectEntity PowerMeterPlugIndicatorMode => new(_haContext, "select.power_meter_plug_indicator_mode");
		///<summary>PC-Acc&Fridge Power Meter power outage memory</summary>
		public SelectEntity PowerMeterPlugPowerOutageMemory => new(_haContext, "select.power_meter_plug_power_outage_memory");
		///<summary>Kitchen Power Meter-Plug indicator mode</summary>
		public SelectEntity RefrigeratorPlugIndicatorMode => new(_haContext, "select.refrigerator_plug_indicator_mode");
		///<summary>Kitchen Power Meter-Plug power outage memory</summary>
		public SelectEntity RefrigeratorPlugPowerOutageMemory => new(_haContext, "select.refrigerator_plug_power_outage_memory");
		///<summary>Storage Light power on behavior</summary>
		public SelectEntity StorageLightPowerOnBehavior => new(_haContext, "select.storage_light_power_on_behavior");
		///<summary>Toilet Light_1_power_on_behavior</summary>
		public SelectEntity ToiletLight1PowerOnBehavior => new(_haContext, "select.toilet_light_1_power_on_behavior");
		///<summary>Toilet Sensor motion sensitivity</summary>
		public SelectEntity ToiletSensorMotionSensitivity => new(_haContext, "select.toilet_sensor_motion_sensitivity");
		///<summary>Tv Power Meter indicator mode</summary>
		public SelectEntity TvPowerMeterIndicatorMode => new(_haContext, "select.tv_power_meter_indicator_mode");
		///<summary>Tv Power Meter power outage memory</summary>
		public SelectEntity TvPowerMeterPowerOutageMemory => new(_haContext, "select.tv_power_meter_power_outage_memory");
	}

	public partial class SensorEntities
	{
		private readonly IHaContext _haContext;
		public SensorEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>PC Sensor battery</summary>
		public NumericSensorEntity E0x001788010bcfb16fBattery => new(_haContext, "sensor.0x001788010bcfb16f_battery");
		///<summary>PC Sensor illuminance lux</summary>
		public NumericSensorEntity E0x001788010bcfb16fIlluminanceLux => new(_haContext, "sensor.0x001788010bcfb16f_illuminance_lux");
		///<summary>PC Sensor temperature</summary>
		public NumericSensorEntity E0x001788010bcfb16fTemperature => new(_haContext, "sensor.0x001788010bcfb16f_temperature");
		///<summary>All Lights Daily Conpumption</summary>
		public NumericSensorEntity AllLightDailyConsumption => new(_haContext, "sensor.all_light_daily_consumption");
		///<summary>Back Corner Energy Daily Consumption</summary>
		public NumericSensorEntity BackCornerEnergyDailyConsumption => new(_haContext, "sensor.back_corner_energy_daily_consumption");
		///<summary>Back Corner Plug energy</summary>
		public NumericSensorEntity BackCornerPlugEnergy => new(_haContext, "sensor.back_corner_plug_energy");
		///<summary>Back Corner Power</summary>
		public NumericSensorEntity BackCornerPlugPower => new(_haContext, "sensor.back_corner_plug_power");
		///<summary>Cube action angle</summary>
		public NumericSensorEntity CubeActionAngle => new(_haContext, "sensor.cube_action_angle");
		///<summary>Cube battery</summary>
		public NumericSensorEntity CubeBattery => new(_haContext, "sensor.cube_battery");
		///<summary>Cube device temperature</summary>
		public NumericSensorEntity CubeDeviceTemperature => new(_haContext, "sensor.cube_device_temperature");
		///<summary>Total Energy</summary>
		public NumericSensorEntity EnergyTotal => new(_haContext, "sensor.energy_total");
		///<summary>Total PC Energy</summary>
		public NumericSensorEntity EnergyTotalPc => new(_haContext, "sensor.energy_total_pc");
		///<summary>ENVY_battery Charge Remaining Percentage</summary>
		public NumericSensorEntity EnvyBatteryChargeRemainingPercentage => new(_haContext, "sensor.envy_battery_charge_remaining_percentage");
		///<summary>Estimated Energy Cost</summary>
		public NumericSensorEntity EstimatedDailyEnergycost => new(_haContext, "sensor.estimated_daily_energycost");
		///<summary>Total PC Wattage</summary>
		public NumericSensorEntity EstimatedDailyEnergycost2 => new(_haContext, "sensor.estimated_daily_energycost_2");
		///<summary>Kitchen Power Consumption</summary>
		public NumericSensorEntity FridgePowerConsumption => new(_haContext, "sensor.fridge_power_consumption");
		///<summary>Front-Door Sensor battery</summary>
		public NumericSensorEntity FrontDoorSensorBattery => new(_haContext, "sensor.front_door_sensor_battery");
		///<summary>Front-Door Sensor device temperature</summary>
		public NumericSensorEntity FrontDoorSensorDeviceTemperature => new(_haContext, "sensor.front_door_sensor_device_temperature");
		///<summary>hacs</summary>
		public NumericSensorEntity Hacs => new(_haContext, "sensor.hacs");
		///<summary>Hallway Sensor battery</summary>
		public NumericSensorEntity HallwaySensorBattery2 => new(_haContext, "sensor.hallway_sensor_battery_2");
		///<summary>Hallway Sensor illuminance lux</summary>
		public NumericSensorEntity HallwaySensorIlluminanceLux => new(_haContext, "sensor.hallway_sensor_illuminance_lux");
		///<summary>Hallway Sensor temperature</summary>
		public NumericSensorEntity HallwaySensorTemperature2 => new(_haContext, "sensor.hallway_sensor_temperature_2");
		///<summary>Hourly Energy</summary>
		public NumericSensorEntity HourlyEnergy => new(_haContext, "sensor.hourly_energy");
		///<summary>Hue Switch Bed battery</summary>
		public NumericSensorEntity HueSwitchBedBattery => new(_haContext, "sensor.hue_switch_bed_battery");
		///<summary>Hue Switch Living Room battery</summary>
		public NumericSensorEntity HueSwitchLivingRoomBattery => new(_haContext, "sensor.hue_switch_living_room_battery");
		///<summary>Kitchen distance</summary>
		public NumericSensorEntity KitchenDistance => new(_haContext, "sensor.kitchen_distance");
		///<summary>Kitchen Sensor battery</summary>
		public NumericSensorEntity KitchenSensorBattery2 => new(_haContext, "sensor.kitchen_sensor_battery_2");
		///<summary>Kitchen Sensor illuminance lux</summary>
		public NumericSensorEntity KitchenSensorIlluminanceLux => new(_haContext, "sensor.kitchen_sensor_illuminance_lux");
		///<summary>Kitchen Sensor temperature</summary>
		public NumericSensorEntity KitchenSensorTemperature2 => new(_haContext, "sensor.kitchen_sensor_temperature_2");
		///<summary>Fridge, Modem, PI Daily Consumption</summary>
		public NumericSensorEntity MiscPowerMeterConsumption => new(_haContext, "sensor.misc_power_meter_consumption");
		///<summary>moto g(8) power lite Battery Level</summary>
		public NumericSensorEntity MotoG8PowerLiteBatteryLevel => new(_haContext, "sensor.moto_g_8_power_lite_battery_level");
		///<summary>nordpool_kwh_fi_eur_3_10_01</summary>
		public NumericSensorEntity NordpoolKwhFiEur31001 => new(_haContext, "sensor.nordpool_kwh_fi_eur_3_10_01");
		///<summary>Outside temperature meter Battery</summary>
		public NumericSensorEntity OutsideTemperatureMeterBattery => new(_haContext, "sensor.outside_temperature_meter_battery");
		///<summary>Outside temperature meter Humidity</summary>
		public NumericSensorEntity OutsideTemperatureMeterHumidity => new(_haContext, "sensor.outside_temperature_meter_humidity");
		///<summary>Outside temperature meter Luminosity</summary>
		public NumericSensorEntity OutsideTemperatureMeterLuminosity => new(_haContext, "sensor.outside_temperature_meter_luminosity");
		///<summary>Outside temperature meter Temperature</summary>
		public NumericSensorEntity OutsideTemperatureMeterTemperature => new(_haContext, "sensor.outside_temperature_meter_temperature");
		///<summary>Pc accesories Daily Energy</summary>
		public NumericSensorEntity PcAccesoriesEnergymeterDaily => new(_haContext, "sensor.pc_accesories_energymeter_daily");
		///<summary>PC Energy Consumption (Daily)</summary>
		public NumericSensorEntity PcEnergyConsumptionDaily => new(_haContext, "sensor.pc_energy_consumption_daily");
		///<summary>Pc Energy Consumption (Hourly)</summary>
		public NumericSensorEntity PcEnergyConsumptionHourly => new(_haContext, "sensor.pc_energy_consumption_hourly");
		///<summary>PC_memoryusage</summary>
		public NumericSensorEntity PcMemoryusage => new(_haContext, "sensor.pc_memoryusage");
		///<summary>Pc On today</summary>
		public NumericSensorEntity PcOnToday => new(_haContext, "sensor.pc_on_today");
		///<summary>PC-Plug energy</summary>
		public NumericSensorEntity PcPlugEnergy => new(_haContext, "sensor.pc_plug_energy");
		///<summary>PC-Plug power</summary>
		public NumericSensorEntity PcPlugPower => new(_haContext, "sensor.pc_plug_power");
		///<summary>Power Meter (General) energy</summary>
		public NumericSensorEntity PowerMeterGeneralEnergy => new(_haContext, "sensor.power_meter_general_energy");
		///<summary>Fridge, Modem, PI Power</summary>
		public NumericSensorEntity PowerMeterGeneralPower => new(_haContext, "sensor.power_meter_general_power");
		///<summary>Power meter (hourly)</summary>
		public NumericSensorEntity PowerMeterHourly => new(_haContext, "sensor.power_meter_hourly");
		///<summary>PC-Acc&Fridge Power Meter energy</summary>
		public NumericSensorEntity PowerMeterPlugEnergy => new(_haContext, "sensor.power_meter_plug_energy");
		///<summary>Pc Accessories Power</summary>
		public NumericSensorEntity PowerMeterPlugPower => new(_haContext, "sensor.power_meter_plug_power");
		///<summary>Kitchen Power Meter-Plug energy</summary>
		public NumericSensorEntity RefrigeratorPlugEnergy => new(_haContext, "sensor.refrigerator_plug_energy");
		///<summary>Kitchen Power Meter-Plug power</summary>
		public NumericSensorEntity RefrigeratorPlugPower => new(_haContext, "sensor.refrigerator_plug_power");
		///<summary>SM-T530 Battery Level</summary>
		public NumericSensorEntity SmT530BatteryLevel => new(_haContext, "sensor.sm_t530_battery_level");
		///<summary>Storage Sensor battery</summary>
		public NumericSensorEntity StorageSensorAqaraBattery => new(_haContext, "sensor.storage_sensor_aqara_battery");
		///<summary>Storage Sensor device temperature</summary>
		public NumericSensorEntity StorageSensorAqaraDeviceTemperature => new(_haContext, "sensor.storage_sensor_aqara_device_temperature");
		///<summary>Storage Sensor illuminance lux</summary>
		public NumericSensorEntity StorageSensorAqaraIlluminanceLux => new(_haContext, "sensor.storage_sensor_aqara_illuminance_lux");
		///<summary>Surface_Laptop_battery Charge Remaining Percentage</summary>
		public NumericSensorEntity SurfaceLaptopBatteryChargeRemainingPercentage => new(_haContext, "sensor.surface_laptop_battery_charge_remaining_percentage");
		///<summary>Toilet Seat Sensor battery</summary>
		public NumericSensorEntity ToiletSeatSensorBattery => new(_haContext, "sensor.toilet_seat_sensor_battery");
		///<summary>Toilet Seat Sensor device temperature</summary>
		public NumericSensorEntity ToiletSeatSensorDeviceTemperature => new(_haContext, "sensor.toilet_seat_sensor_device_temperature");
		///<summary>Toilet Sensor battery</summary>
		public NumericSensorEntity ToiletSensorBattery2 => new(_haContext, "sensor.toilet_sensor_battery_2");
		///<summary>Toilet Sensor illuminance lux</summary>
		public NumericSensorEntity ToiletSensorIlluminanceLux => new(_haContext, "sensor.toilet_sensor_illuminance_lux");
		///<summary>Toilet Sensor temperature</summary>
		public NumericSensorEntity ToiletSensorTemperature2 => new(_haContext, "sensor.toilet_sensor_temperature_2");
		///<summary>Total Energy Hourly</summary>
		public NumericSensorEntity TotalEnergyHourly => new(_haContext, "sensor.total_energy_hourly");
		///<summary>Tv Power Meter Daily</summary>
		public NumericSensorEntity TvPowerMeterDaily => new(_haContext, "sensor.tv_power_meter_daily");
		///<summary>Tv Power Meter energy</summary>
		public NumericSensorEntity TvPowerMeterEnergy => new(_haContext, "sensor.tv_power_meter_energy");
		///<summary>Tv Power Meter power</summary>
		public NumericSensorEntity TvPowerMeterPower => new(_haContext, "sensor.tv_power_meter_power");
		///<summary>Fridge Sensor Humidity</summary>
		public NumericSensorEntity WifiTemperatureHumiditySensorHumidity => new(_haContext, "sensor.wifi_temperature_humidity_sensor_humidity");
		///<summary>Fridge Sensor Temperature</summary>
		public NumericSensorEntity WifiTemperatureHumiditySensorTemperature => new(_haContext, "sensor.wifi_temperature_humidity_sensor_temperature");
		///<summary>Cube action</summary>
		public SensorEntity CubeAction => new(_haContext, "sensor.cube_action");
		///<summary>Cube action from side</summary>
		public SensorEntity CubeActionFromSide => new(_haContext, "sensor.cube_action_from_side");
		///<summary>Cube action side</summary>
		public SensorEntity CubeActionSide => new(_haContext, "sensor.cube_action_side");
		///<summary>Cube action to side</summary>
		public SensorEntity CubeActionToSide => new(_haContext, "sensor.cube_action_to_side");
		///<summary>Cube power outage count</summary>
		public SensorEntity CubePowerOutageCount => new(_haContext, "sensor.cube_power_outage_count");
		///<summary>Cube side</summary>
		public SensorEntity CubeSide => new(_haContext, "sensor.cube_side");
		///<summary>ENVY_battery Charge Remaining</summary>
		public SensorEntity EnvyBatteryChargeRemaining => new(_haContext, "sensor.envy_battery_charge_remaining");
		///<summary>ENVY_battery Charge Status</summary>
		public SensorEntity EnvyBatteryChargeStatus => new(_haContext, "sensor.envy_battery_charge_status");
		///<summary>ENVY_battery Full Charge Lifetime</summary>
		public SensorEntity EnvyBatteryFullChargeLifetime => new(_haContext, "sensor.envy_battery_full_charge_lifetime");
		///<summary>ENVY_battery Powerline Status</summary>
		public SensorEntity EnvyBatteryPowerlineStatus => new(_haContext, "sensor.envy_battery_powerline_status");
		///<summary>ENVY_display \\.\DISPLAY1 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay1BitsPerPixel => new(_haContext, "sensor.envy_display_display1_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY1 Name</summary>
		public SensorEntity EnvyDisplayDisplay1Name => new(_haContext, "sensor.envy_display_display1_name");
		///<summary>ENVY_display \\.\DISPLAY1 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay1Resolution => new(_haContext, "sensor.envy_display_display1_resolution");
		///<summary>ENVY_display DISPLAY2</summary>
		public SensorEntity EnvyDisplayDisplay2 => new(_haContext, "sensor.envy_display_display2");
		///<summary>ENVY_display \\.\DISPLAY2 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay2BitsPerPixel => new(_haContext, "sensor.envy_display_display2_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY2 Name</summary>
		public SensorEntity EnvyDisplayDisplay2Name => new(_haContext, "sensor.envy_display_display2_name");
		///<summary>ENVY_display \\.\DISPLAY2 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay2Resolution => new(_haContext, "sensor.envy_display_display2_resolution");
		///<summary>ENVY_display DISPLAY3</summary>
		public SensorEntity EnvyDisplayDisplay3 => new(_haContext, "sensor.envy_display_display3");
		///<summary>ENVY_display \\.\DISPLAY3 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay3BitsPerPixel => new(_haContext, "sensor.envy_display_display3_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY3 Name</summary>
		public SensorEntity EnvyDisplayDisplay3Name => new(_haContext, "sensor.envy_display_display3_name");
		///<summary>ENVY_display \\.\DISPLAY3 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay3Resolution => new(_haContext, "sensor.envy_display_display3_resolution");
		///<summary>ENVY_display DISPLAY6</summary>
		public SensorEntity EnvyDisplayDisplay6 => new(_haContext, "sensor.envy_display_display6");
		///<summary>ENVY_display \\.\DISPLAY6 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay6BitsPerPixel => new(_haContext, "sensor.envy_display_display6_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY6 Name</summary>
		public SensorEntity EnvyDisplayDisplay6Name => new(_haContext, "sensor.envy_display_display6_name");
		///<summary>ENVY_display \\.\DISPLAY6 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay6Resolution => new(_haContext, "sensor.envy_display_display6_resolution");
		///<summary>ENVY_display DISPLAY7</summary>
		public SensorEntity EnvyDisplayDisplay7 => new(_haContext, "sensor.envy_display_display7");
		///<summary>ENVY_display \\.\DISPLAY7 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay7BitsPerPixel => new(_haContext, "sensor.envy_display_display7_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY7 Name</summary>
		public SensorEntity EnvyDisplayDisplay7Name => new(_haContext, "sensor.envy_display_display7_name");
		///<summary>ENVY_display \\.\DISPLAY7 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay7Resolution => new(_haContext, "sensor.envy_display_display7_resolution");
		///<summary>ENVY_display DISPLAY8</summary>
		public SensorEntity EnvyDisplayDisplay8 => new(_haContext, "sensor.envy_display_display8");
		///<summary>ENVY_display \\.\DISPLAY8 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay8BitsPerPixel => new(_haContext, "sensor.envy_display_display8_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY8 Name</summary>
		public SensorEntity EnvyDisplayDisplay8Name => new(_haContext, "sensor.envy_display_display8_name");
		///<summary>ENVY_display \\.\DISPLAY8 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay8Resolution => new(_haContext, "sensor.envy_display_display8_resolution");
		///<summary>ENVY_display \\.\DISPLAY9 Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayDisplay9BitsPerPixel => new(_haContext, "sensor.envy_display_display9_bits_per_pixel");
		///<summary>ENVY_display \\.\DISPLAY9 Name</summary>
		public SensorEntity EnvyDisplayDisplay9Name => new(_haContext, "sensor.envy_display_display9_name");
		///<summary>ENVY_display \\.\DISPLAY9 Resolution</summary>
		public SensorEntity EnvyDisplayDisplay9Resolution => new(_haContext, "sensor.envy_display_display9_resolution");
		///<summary>ENVY_display WinDisc Bits Per Pixel</summary>
		public SensorEntity EnvyDisplayWindiscBitsPerPixel => new(_haContext, "sensor.envy_display_windisc_bits_per_pixel");
		///<summary>ENVY_display WinDisc Name</summary>
		public SensorEntity EnvyDisplayWindiscName => new(_haContext, "sensor.envy_display_windisc_name");
		///<summary>ENVY_display WinDisc Resolution</summary>
		public SensorEntity EnvyDisplayWindiscResolution => new(_haContext, "sensor.envy_display_windisc_resolution");
		///<summary>ENVY_lastactive</summary>
		public SensorEntity EnvyLastactive => new(_haContext, "sensor.envy_lastactive");
		///<summary>ENVY_network Ethernet 3</summary>
		public SensorEntity EnvyNetworkEthernet3 => new(_haContext, "sensor.envy_network_ethernet_3");
		///<summary>ENVY_network Network Card Count</summary>
		public SensorEntity EnvyNetworkNetworkCardCount => new(_haContext, "sensor.envy_network_network_card_count");
		///<summary>Front-Door Sensor power outage count</summary>
		public SensorEntity FrontDoorSensorPowerOutageCount => new(_haContext, "sensor.front_door_sensor_power_outage_count");
		///<summary>Hue Switch Bed action</summary>
		public SensorEntity HueSwitchBedAction => new(_haContext, "sensor.hue_switch_bed_action");
		///<summary>Hue Switch Living Room action</summary>
		public SensorEntity HueSwitchLivingRoomAction => new(_haContext, "sensor.hue_switch_living_room_action");
		///<summary>moto g(8) power lite Last Notification</summary>
		public SensorEntity MotoG8PowerLiteLastNotification => new(_haContext, "sensor.moto_g_8_power_lite_last_notification");
		///<summary>moto g(8) power lite Media Session</summary>
		public SensorEntity MotoG8PowerLiteMediaSession => new(_haContext, "sensor.moto_g_8_power_lite_media_session");
		///<summary>PC_audio Audio Sessions</summary>
		public SensorEntity PcAudioAudioSessions => new(_haContext, "sensor.pc_audio_audio_sessions");
		///<summary>PC_audio Default Device</summary>
		public SensorEntity PcAudioDefaultDevice => new(_haContext, "sensor.pc_audio_default_device");
		///<summary>PC_audio Default Device Muted</summary>
		public SensorEntity PcAudioDefaultDeviceMuted => new(_haContext, "sensor.pc_audio_default_device_muted");
		///<summary>PC_audio Default Device State</summary>
		public SensorEntity PcAudioDefaultDeviceState => new(_haContext, "sensor.pc_audio_default_device_state");
		///<summary>PC_audio Default Device Volume</summary>
		public SensorEntity PcAudioDefaultDeviceVolume => new(_haContext, "sensor.pc_audio_default_device_volume");
		///<summary>PC_audio Default Input Device</summary>
		public SensorEntity PcAudioDefaultInputDevice => new(_haContext, "sensor.pc_audio_default_input_device");
		///<summary>PC_audio Default Input Device Muted</summary>
		public SensorEntity PcAudioDefaultInputDeviceMuted => new(_haContext, "sensor.pc_audio_default_input_device_muted");
		///<summary>PC_audio Default Input Device State</summary>
		public SensorEntity PcAudioDefaultInputDeviceState => new(_haContext, "sensor.pc_audio_default_input_device_state");
		///<summary>PC_audio Default Input Device Volume</summary>
		public SensorEntity PcAudioDefaultInputDeviceVolume => new(_haContext, "sensor.pc_audio_default_input_device_volume");
		///<summary>PC_audio Peak Volume</summary>
		public SensorEntity PcAudioPeakVolume => new(_haContext, "sensor.pc_audio_peak_volume");
		///<summary>PC_display Display Count</summary>
		public SensorEntity PcDisplayDisplayCount => new(_haContext, "sensor.pc_display_display_count");
		///<summary>PC_display DISPLAY1</summary>
		public SensorEntity PcDisplayDisplay1 => new(_haContext, "sensor.pc_display_display1");
		///<summary>PC_display \\.\DISPLAY1 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay1BitsPerPixel => new(_haContext, "sensor.pc_display_display1_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY1 Name</summary>
		public SensorEntity PcDisplayDisplay1Name => new(_haContext, "sensor.pc_display_display1_name");
		///<summary>PC_display \\.\DISPLAY1 Resolution</summary>
		public SensorEntity PcDisplayDisplay1Resolution => new(_haContext, "sensor.pc_display_display1_resolution");
		///<summary>PC_display DISPLAY2</summary>
		public SensorEntity PcDisplayDisplay2 => new(_haContext, "sensor.pc_display_display2");
		///<summary>PC_display \\.\DISPLAY2 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay2BitsPerPixel => new(_haContext, "sensor.pc_display_display2_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY2 Name</summary>
		public SensorEntity PcDisplayDisplay2Name => new(_haContext, "sensor.pc_display_display2_name");
		///<summary>PC_display \\.\DISPLAY2 Resolution</summary>
		public SensorEntity PcDisplayDisplay2Resolution => new(_haContext, "sensor.pc_display_display2_resolution");
		///<summary>PC_display DISPLAY3</summary>
		public SensorEntity PcDisplayDisplay3 => new(_haContext, "sensor.pc_display_display3");
		///<summary>PC_display \\.\DISPLAY3 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay3BitsPerPixel => new(_haContext, "sensor.pc_display_display3_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY3 Name</summary>
		public SensorEntity PcDisplayDisplay3Name => new(_haContext, "sensor.pc_display_display3_name");
		///<summary>PC_display \\.\DISPLAY3 Resolution</summary>
		public SensorEntity PcDisplayDisplay3Resolution => new(_haContext, "sensor.pc_display_display3_resolution");
		///<summary>PC_display DISPLAY4</summary>
		public SensorEntity PcDisplayDisplay4 => new(_haContext, "sensor.pc_display_display4");
		///<summary>PC_display \\.\DISPLAY4 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay4BitsPerPixel => new(_haContext, "sensor.pc_display_display4_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY4 Name</summary>
		public SensorEntity PcDisplayDisplay4Name => new(_haContext, "sensor.pc_display_display4_name");
		///<summary>PC_display \\.\DISPLAY4 Resolution</summary>
		public SensorEntity PcDisplayDisplay4Resolution => new(_haContext, "sensor.pc_display_display4_resolution");
		///<summary>PC_display DISPLAY6</summary>
		public SensorEntity PcDisplayDisplay6 => new(_haContext, "sensor.pc_display_display6");
		///<summary>PC_display \\.\DISPLAY6 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay6BitsPerPixel => new(_haContext, "sensor.pc_display_display6_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY6 Name</summary>
		public SensorEntity PcDisplayDisplay6Name => new(_haContext, "sensor.pc_display_display6_name");
		///<summary>PC_display \\.\DISPLAY6 Resolution</summary>
		public SensorEntity PcDisplayDisplay6Resolution => new(_haContext, "sensor.pc_display_display6_resolution");
		///<summary>PC_display DISPLAY7</summary>
		public SensorEntity PcDisplayDisplay7 => new(_haContext, "sensor.pc_display_display7");
		///<summary>PC_display \\.\DISPLAY7 Bits Per Pixel</summary>
		public SensorEntity PcDisplayDisplay7BitsPerPixel => new(_haContext, "sensor.pc_display_display7_bits_per_pixel");
		///<summary>PC_display \\.\DISPLAY7 Name</summary>
		public SensorEntity PcDisplayDisplay7Name => new(_haContext, "sensor.pc_display_display7_name");
		///<summary>PC_display \\.\DISPLAY7 Resolution</summary>
		public SensorEntity PcDisplayDisplay7Resolution => new(_haContext, "sensor.pc_display_display7_resolution");
		///<summary>PC_display DISPLAY8</summary>
		public SensorEntity PcDisplayDisplay8 => new(_haContext, "sensor.pc_display_display8");
		///<summary>PC_display Primary Display</summary>
		public SensorEntity PcDisplayPrimaryDisplay => new(_haContext, "sensor.pc_display_primary_display");
		///<summary>PC_display WinDisc</summary>
		public SensorEntity PcDisplayWindisc => new(_haContext, "sensor.pc_display_windisc");
		///<summary>PC_display WinDisc Bits Per Pixel</summary>
		public SensorEntity PcDisplayWindiscBitsPerPixel => new(_haContext, "sensor.pc_display_windisc_bits_per_pixel");
		///<summary>PC_display WinDisc Name</summary>
		public SensorEntity PcDisplayWindiscName => new(_haContext, "sensor.pc_display_windisc_name");
		///<summary>PC_display WinDisc Resolution</summary>
		public SensorEntity PcDisplayWindiscResolution => new(_haContext, "sensor.pc_display_windisc_resolution");
		///<summary>PC_lastactive</summary>
		public SensorEntity PcLastactive => new(_haContext, "sensor.pc_lastactive");
		///<summary>SM-T530 Media Session</summary>
		public SensorEntity SmT530MediaSession => new(_haContext, "sensor.sm_t530_media_session");
		///<summary>Storage Sensor power outage count</summary>
		public SensorEntity StorageSensorAqaraPowerOutageCount => new(_haContext, "sensor.storage_sensor_aqara_power_outage_count");
		///<summary>Surface_Laptop_battery Charge Remaining</summary>
		public SensorEntity SurfaceLaptopBatteryChargeRemaining => new(_haContext, "sensor.surface_laptop_battery_charge_remaining");
		///<summary>Surface_Laptop_battery Charge Status</summary>
		public SensorEntity SurfaceLaptopBatteryChargeStatus => new(_haContext, "sensor.surface_laptop_battery_charge_status");
		///<summary>Surface_Laptop_battery Full Charge Lifetime</summary>
		public SensorEntity SurfaceLaptopBatteryFullChargeLifetime => new(_haContext, "sensor.surface_laptop_battery_full_charge_lifetime");
		///<summary>Surface_Laptop_battery Powerline Status</summary>
		public SensorEntity SurfaceLaptopBatteryPowerlineStatus => new(_haContext, "sensor.surface_laptop_battery_powerline_status");
		///<summary>Surface Laptop_lastactive</summary>
		public SensorEntity SurfaceLaptopLastactive => new(_haContext, "sensor.surface_laptop_lastactive");
		///<summary>Toilet Seat Sensor power outage count</summary>
		public SensorEntity ToiletSeatSensorPowerOutageCount => new(_haContext, "sensor.toilet_seat_sensor_power_outage_count");
		///<summary>Fridge Sensor Battery state</summary>
		public SensorEntity WifiTemperatureHumiditySensorBatteryState => new(_haContext, "sensor.wifi_temperature_humidity_sensor_battery_state");
	}

	public partial class SwitchEntities
	{
		private readonly IHaContext _haContext;
		public SwitchEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>PC Sensor led_indication</summary>
		public SwitchEntity E0x001788010bcfb16fLedIndication => new(_haContext, "switch.0x001788010bcfb16f_led_indication");
		///<summary>Back Corner Plug</summary>
		public SwitchEntity BackCornerPlug => new(_haContext, "switch.back_corner_plug");
		///<summary>TV</summary>
		public SwitchEntity BedMultiPlugL1 => new(_haContext, "switch.bed_multi_plug_l1");
		///<summary>Fan</summary>
		public SwitchEntity BedMultiPlugL2 => new(_haContext, "switch.bed_multi_plug_l2");
		///<summary>Chargers</summary>
		public SwitchEntity BedMultiPlugL3 => new(_haContext, "switch.bed_multi_plug_l3");
		///<summary>Smart Speaker Plug</summary>
		public SwitchEntity BrightLightPlug => new(_haContext, "switch.bright_light_plug");
		///<summary>Speaker Plug</summary>
		public SwitchEntity FanPlug => new(_haContext, "switch.fan_plug");
		///<summary>Fridge Sensor Switch</summary>
		public SwitchEntity FridgeSensorSwitch => new(_haContext, "switch.fridge_sensor_switch");
		///<summary>Hallway Sensor led_indication</summary>
		public SwitchEntity HallwaySensorLedIndication => new(_haContext, "switch.hallway_sensor_led_indication");
		///<summary>Kitchen Sensor led_indication</summary>
		public SwitchEntity KitchenSensorLedIndication => new(_haContext, "switch.kitchen_sensor_led_indication");
		///<summary>Outside temperature meter Switch</summary>
		public SwitchEntity OutsideTemperatureMeterSwitch => new(_haContext, "switch.outside_temperature_meter_switch");
		///<summary>PC Connector Child Lock</summary>
		public SwitchEntity PcConnectorChildLock => new(_haContext, "switch.pc_connector_child_lock");
		///<summary>Multi Plug: Bright Light</summary>
		public SwitchEntity PcConnectorSocket1 => new(_haContext, "switch.pc_connector_socket_1");
		///<summary>MultiPlug 2 - PC Monitors</summary>
		public SwitchEntity PcConnectorSocket2 => new(_haContext, "switch.pc_connector_socket_2");
		///<summary>Multi Plug 3 - Nest</summary>
		public SwitchEntity PcConnectorSocket3 => new(_haContext, "switch.pc_connector_socket_3");
		///<summary>Multi Plug USB</summary>
		public SwitchEntity PcConnectorSocket4 => new(_haContext, "switch.pc_connector_socket_4");
		///<summary>PC-Plug</summary>
		public SwitchEntity PcPlug => new(_haContext, "switch.pc_plug");
		///<summary>Power Meter (General)</summary>
		public SwitchEntity PowerMeterGeneral => new(_haContext, "switch.power_meter_general");
		///<summary>PC-Acc&Fridge Power Meter</summary>
		public SwitchEntity PowerMeterPlug => new(_haContext, "switch.power_meter_plug");
		///<summary>Qnap</summary>
		public SwitchEntity Qnap => new(_haContext, "switch.qnap");
		///<summary>Kitchen Power Meter-Plug</summary>
		public SwitchEntity RefrigeratorPlug => new(_haContext, "switch.refrigerator_plug");
		///<summary>Laptop Plug Desktop</summary>
		public SwitchEntity RunnerPlug => new(_haContext, "switch.runner_plug");
		///<summary>Schedule #9ee8ea</summary>
		public SwitchEntity Schedule9ee8ea => new(_haContext, "switch.schedule_9ee8ea");
		///<summary>Toilet Sensor led_indication</summary>
		public SwitchEntity ToiletSensorLedIndication => new(_haContext, "switch.toilet_sensor_led_indication");
		///<summary>Tv Power Meter</summary>
		public SwitchEntity TvPowerMeter => new(_haContext, "switch.tv_power_meter");
	}

	public partial class UpdateEntities
	{
		private readonly IHaContext _haContext;
		public UpdateEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Back Corner Plug</summary>
		public UpdateEntity BackCornerPlug => new(_haContext, "update.back_corner_plug");
		///<summary>Bed Light</summary>
		public UpdateEntity BedLight => new(_haContext, "update.bed_light");
		///<summary>Bed Light Plug</summary>
		public UpdateEntity BedLightPlug => new(_haContext, "update.bed_light_plug");
		///<summary>Desktop Light</summary>
		public UpdateEntity DesktopLight => new(_haContext, "update.desktop_light");
		///<summary>Duck DNS Update</summary>
		public UpdateEntity DuckDnsUpdate => new(_haContext, "update.duck_dns_update");
		///<summary>Fan Plug</summary>
		public UpdateEntity FanPlug => new(_haContext, "update.fan_plug");
		///<summary>File editor Update</summary>
		public UpdateEntity FileEditorUpdate => new(_haContext, "update.file_editor_update");
		///<summary>FTP Update</summary>
		public UpdateEntity FtpUpdate => new(_haContext, "update.ftp_update");
		///<summary>Hallway Light</summary>
		public UpdateEntity HallwayLight => new(_haContext, "update.hallway_light");
		///<summary>Hallway Sensor</summary>
		public UpdateEntity HallwaySensor => new(_haContext, "update.hallway_sensor");
		///<summary>Home Assistant Core Update</summary>
		public UpdateEntity HomeAssistantCoreUpdate => new(_haContext, "update.home_assistant_core_update");
		///<summary>Home Assistant Google Drive Backup Update</summary>
		public UpdateEntity HomeAssistantGoogleDriveBackupUpdate => new(_haContext, "update.home_assistant_google_drive_backup_update");
		///<summary>Home Assistant Operating System Update</summary>
		public UpdateEntity HomeAssistantOperatingSystemUpdate => new(_haContext, "update.home_assistant_operating_system_update");
		///<summary>Home Assistant Supervisor Update</summary>
		public UpdateEntity HomeAssistantSupervisorUpdate => new(_haContext, "update.home_assistant_supervisor_update");
		///<summary>Hue Switch Bed</summary>
		public UpdateEntity HueSwitchBed => new(_haContext, "update.hue_switch_bed");
		///<summary>Hue Switch Living Room</summary>
		public UpdateEntity HueSwitchLivingRoom => new(_haContext, "update.hue_switch_living_room");
		///<summary>Kitchen Light</summary>
		public UpdateEntity KitchenLight => new(_haContext, "update.kitchen_light");
		///<summary>Kitchen Power Meter-Plug</summary>
		public UpdateEntity KitchenPowerMeterPlug => new(_haContext, "update.kitchen_power_meter_plug");
		///<summary>Kitchen Sensor</summary>
		public UpdateEntity KitchenSensor => new(_haContext, "update.kitchen_sensor");
		///<summary>Living Room Light</summary>
		public UpdateEntity LivingRoomLight => new(_haContext, "update.living_room_light");
		///<summary>MariaDB Update</summary>
		public UpdateEntity MariadbUpdate => new(_haContext, "update.mariadb_update");
		///<summary>Mosquitto broker Update</summary>
		public UpdateEntity MosquittoBrokerUpdate => new(_haContext, "update.mosquitto_broker_update");
		///<summary>NetDaemon V3.1 (.NET 7) Update</summary>
		public UpdateEntity NetdaemonV31Net7Update => new(_haContext, "update.netdaemon_v3_1_net_7_update");
		///<summary>Nginx Proxy Manager Update</summary>
		public UpdateEntity NginxProxyManagerUpdate => new(_haContext, "update.nginx_proxy_manager_update");
		///<summary>PC-Acc&Fridge Power Meter</summary>
		public UpdateEntity PcAccFridgePowerMeter => new(_haContext, "update.pc_acc_fridge_power_meter");
		///<summary>PC-Plug</summary>
		public UpdateEntity PcPlug => new(_haContext, "update.pc_plug");
		///<summary>PC Sensor</summary>
		public UpdateEntity PcSensor => new(_haContext, "update.pc_sensor");
		///<summary>Power Meter (General)</summary>
		public UpdateEntity PowerMeterGeneral => new(_haContext, "update.power_meter_general");
		///<summary>Runner Plug</summary>
		public UpdateEntity RunnerPlug => new(_haContext, "update.runner_plug");
		///<summary>Storage Light</summary>
		public UpdateEntity StorageLight => new(_haContext, "update.storage_light");
		///<summary>Terminal & SSH Update</summary>
		public UpdateEntity TerminalSshUpdate => new(_haContext, "update.terminal_ssh_update");
		///<summary>Toilet Light_1</summary>
		public UpdateEntity ToiletLight1 => new(_haContext, "update.toilet_light_1");
		///<summary>Toilet Sensor</summary>
		public UpdateEntity ToiletSensor => new(_haContext, "update.toilet_sensor");
		///<summary>Tv Power Meter</summary>
		public UpdateEntity TvPowerMeter => new(_haContext, "update.tv_power_meter");
		///<summary>VLC Update</summary>
		public UpdateEntity VlcUpdate => new(_haContext, "update.vlc_update");
		///<summary>Zigbee2MQTT Update</summary>
		public UpdateEntity Zigbee2mqttUpdate => new(_haContext, "update.zigbee2mqtt_update");
	}

	public partial class WeatherEntities
	{
		private readonly IHaContext _haContext;
		public WeatherEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Forecast Home</summary>
		public WeatherEntity Home => new(_haContext, "weather.home");
	}

	public partial class ZoneEntities
	{
		private readonly IHaContext _haContext;
		public ZoneEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Home</summary>
		public ZoneEntity Home => new(_haContext, "zone.home");
	}

	public partial record AutomationEntity : Entity<AutomationEntity, EntityState<AutomationAttributes>, AutomationAttributes>
	{
		public AutomationEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public AutomationEntity(Entity entity) : base(entity)
		{
		}
	}

	public record AutomationAttributes
	{
		[JsonPropertyName("current")]
		public double? Current { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }

		[JsonPropertyName("last_triggered")]
		public string? LastTriggered { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public partial record BinarySensorEntity : Entity<BinarySensorEntity, EntityState<BinarySensorAttributes>, BinarySensorAttributes>
	{
		public BinarySensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public BinarySensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record BinarySensorAttributes
	{
		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("hysteresis")]
		public double? Hysteresis { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("lower")]
		public object? Lower { get; init; }

		[JsonPropertyName("position")]
		public string? Position { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("sensor_value")]
		public double? SensorValue { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("type")]
		public string? Type { get; init; }

		[JsonPropertyName("upper")]
		public double? Upper { get; init; }
	}

	public partial record ButtonEntity : Entity<ButtonEntity, EntityState<ButtonAttributes>, ButtonAttributes>
	{
		public ButtonEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ButtonEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ButtonAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }
	}

	public partial record DeviceTrackerEntity : Entity<DeviceTrackerEntity, EntityState<DeviceTrackerAttributes>, DeviceTrackerAttributes>
	{
		public DeviceTrackerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public DeviceTrackerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record DeviceTrackerAttributes
	{
		[JsonPropertyName("altitude")]
		public double? Altitude { get; init; }

		[JsonPropertyName("course")]
		public double? Course { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("source_type")]
		public string? SourceType { get; init; }

		[JsonPropertyName("speed")]
		public double? Speed { get; init; }

		[JsonPropertyName("vertical_accuracy")]
		public double? VerticalAccuracy { get; init; }
	}

	public partial record InputBooleanEntity : Entity<InputBooleanEntity, EntityState<InputBooleanAttributes>, InputBooleanAttributes>
	{
		public InputBooleanEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputBooleanEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputBooleanAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }
	}

	public partial record InputDatetimeEntity : Entity<InputDatetimeEntity, EntityState<InputDatetimeAttributes>, InputDatetimeAttributes>
	{
		public InputDatetimeEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputDatetimeEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputDatetimeAttributes
	{
		[JsonPropertyName("day")]
		public double? Day { get; init; }

		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("has_date")]
		public bool? HasDate { get; init; }

		[JsonPropertyName("has_time")]
		public bool? HasTime { get; init; }

		[JsonPropertyName("hour")]
		public double? Hour { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("minute")]
		public double? Minute { get; init; }

		[JsonPropertyName("month")]
		public double? Month { get; init; }

		[JsonPropertyName("second")]
		public double? Second { get; init; }

		[JsonPropertyName("timestamp")]
		public double? Timestamp { get; init; }

		[JsonPropertyName("year")]
		public double? Year { get; init; }
	}

	public partial record InputNumberEntity : NumericEntity<InputNumberEntity, NumericEntityState<InputNumberAttributes>, InputNumberAttributes>
	{
		public InputNumberEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputNumberEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputNumberAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("initial")]
		public object? Initial { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("min")]
		public double? Min { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("step")]
		public double? Step { get; init; }

		[JsonPropertyName("unit_of_measurement")]
		public string? UnitOfMeasurement { get; init; }
	}

	public partial record InputSelectEntity : Entity<InputSelectEntity, EntityState<InputSelectAttributes>, InputSelectAttributes>
	{
		public InputSelectEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputSelectEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputSelectAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("options")]
		public IReadOnlyList<string>? Options { get; init; }
	}

	public partial record InputTextEntity : Entity<InputTextEntity, EntityState<InputTextAttributes>, InputTextAttributes>
	{
		public InputTextEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputTextEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputTextAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("min")]
		public double? Min { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("pattern")]
		public object? Pattern { get; init; }
	}

	public partial record LightEntity : Entity<LightEntity, EntityState<LightAttributes>, LightAttributes>
	{
		public LightEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public LightEntity(Entity entity) : base(entity)
		{
		}
	}

	public record LightAttributes
	{
		[JsonPropertyName("brightness")]
		public double? Brightness { get; init; }

		[JsonPropertyName("color_mode")]
		public string? ColorMode { get; init; }

		[JsonPropertyName("effect_list")]
		public IReadOnlyList<string>? EffectList { get; init; }

		[JsonPropertyName("entity_id")]
		public IReadOnlyList<string>? EntityId { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("max_color_temp_kelvin")]
		public double? MaxColorTempKelvin { get; init; }

		[JsonPropertyName("max_mireds")]
		public double? MaxMireds { get; init; }

		[JsonPropertyName("min_color_temp_kelvin")]
		public double? MinColorTempKelvin { get; init; }

		[JsonPropertyName("min_mireds")]
		public double? MinMireds { get; init; }

		[JsonPropertyName("supported_color_modes")]
		public IReadOnlyList<string>? SupportedColorModes { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public partial record LockEntity : Entity<LockEntity, EntityState<LockAttributes>, LockAttributes>
	{
		public LockEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public LockEntity(Entity entity) : base(entity)
		{
		}
	}

	public record LockAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public partial record MediaPlayerEntity : Entity<MediaPlayerEntity, EntityState<MediaPlayerAttributes>, MediaPlayerAttributes>
	{
		public MediaPlayerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public MediaPlayerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record MediaPlayerAttributes
	{
		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("is_volume_muted")]
		public bool? IsVolumeMuted { get; init; }

		[JsonPropertyName("media_album_artist")]
		public string? MediaAlbumArtist { get; init; }

		[JsonPropertyName("media_album_name")]
		public string? MediaAlbumName { get; init; }

		[JsonPropertyName("media_artist")]
		public string? MediaArtist { get; init; }

		[JsonPropertyName("media_content_type")]
		public string? MediaContentType { get; init; }

		[JsonPropertyName("media_duration")]
		public double? MediaDuration { get; init; }

		[JsonPropertyName("media_position")]
		public double? MediaPosition { get; init; }

		[JsonPropertyName("media_position_updated_at")]
		public string? MediaPositionUpdatedAt { get; init; }

		[JsonPropertyName("media_title")]
		public string? MediaTitle { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }
	}

	public partial record NumberEntity : NumericEntity<NumberEntity, NumericEntityState<NumberAttributes>, NumberAttributes>
	{
		public NumberEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public NumberEntity(Entity entity) : base(entity)
		{
		}
	}

	public record NumberAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("min")]
		public double? Min { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("step")]
		public double? Step { get; init; }

		[JsonPropertyName("unit_of_measurement")]
		public string? UnitOfMeasurement { get; init; }
	}

	public partial record PersistentNotificationEntity : Entity<PersistentNotificationEntity, EntityState<PersistentNotificationAttributes>, PersistentNotificationAttributes>
	{
		public PersistentNotificationEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public PersistentNotificationEntity(Entity entity) : base(entity)
		{
		}
	}

	public record PersistentNotificationAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("message")]
		public string? Message { get; init; }

		[JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public partial record PersonEntity : Entity<PersonEntity, EntityState<PersonAttributes>, PersonAttributes>
	{
		public PersonEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public PersonEntity(Entity entity) : base(entity)
		{
		}
	}

	public record PersonAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("source")]
		public string? Source { get; init; }

		[JsonPropertyName("user_id")]
		public string? UserId { get; init; }
	}

	public partial record SceneEntity : Entity<SceneEntity, EntityState<SceneAttributes>, SceneAttributes>
	{
		public SceneEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SceneEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SceneAttributes
	{
		[JsonPropertyName("entity_id")]
		public IReadOnlyList<string>? EntityId { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }
	}

	public partial record ScriptEntity : Entity<ScriptEntity, EntityState<ScriptAttributes>, ScriptAttributes>
	{
		public ScriptEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ScriptEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ScriptAttributes
	{
		[JsonPropertyName("current")]
		public double? Current { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("last_triggered")]
		public string? LastTriggered { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public partial record SelectEntity : Entity<SelectEntity, EntityState<SelectAttributes>, SelectAttributes>
	{
		public SelectEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SelectEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SelectAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("options")]
		public IReadOnlyList<string>? Options { get; init; }
	}

	public partial record NumericSensorEntity : NumericEntity<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>, NumericSensorAttributes>
	{
		public NumericSensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public NumericSensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record NumericSensorAttributes
	{
		[JsonPropertyName("additional_costs_current_hour")]
		public double? AdditionalCostsCurrentHour { get; init; }

		[JsonPropertyName("average")]
		public double? Average { get; init; }

		[JsonPropertyName("country")]
		public string? Country { get; init; }

		[JsonPropertyName("cron pattern")]
		public string? Cronpattern { get; init; }

		[JsonPropertyName("currency")]
		public string? Currency { get; init; }

		[JsonPropertyName("current_price")]
		public double? CurrentPrice { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("last_period")]
		public string? LastPeriod { get; init; }

		[JsonPropertyName("last_reset")]
		public string? LastReset { get; init; }

		[JsonPropertyName("low_price")]
		public bool? LowPrice { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("mean")]
		public double? Mean { get; init; }

		[JsonPropertyName("meter_period")]
		public string? MeterPeriod { get; init; }

		[JsonPropertyName("min")]
		public double? Min { get; init; }

		[JsonPropertyName("off_peak_1")]
		public double? OffPeak1 { get; init; }

		[JsonPropertyName("off_peak_2")]
		public double? OffPeak2 { get; init; }

		[JsonPropertyName("peak")]
		public double? Peak { get; init; }

		[JsonPropertyName("price_percent_to_average")]
		public double? PricePercentToAverage { get; init; }

		[JsonPropertyName("raw_today")]
		public IReadOnlyList<object>? RawToday { get; init; }

		[JsonPropertyName("raw_tomorrow")]
		public IReadOnlyList<object>? RawTomorrow { get; init; }

		[JsonPropertyName("region")]
		public string? Region { get; init; }

		[JsonPropertyName("repositories")]
		public IReadOnlyList<object>? Repositories { get; init; }

		[JsonPropertyName("source")]
		public string? Source { get; init; }

		[JsonPropertyName("state_class")]
		public string? StateClass { get; init; }

		[JsonPropertyName("status")]
		public string? Status { get; init; }

		[JsonPropertyName("today")]
		public IReadOnlyList<double>? Today { get; init; }

		[JsonPropertyName("tomorrow")]
		public IReadOnlyList<object>? Tomorrow { get; init; }

		[JsonPropertyName("tomorrow_valid")]
		public bool? TomorrowValid { get; init; }

		[JsonPropertyName("unit")]
		public string? Unit { get; init; }

		[JsonPropertyName("unit_of_measurement")]
		public string? UnitOfMeasurement { get; init; }
	}

	public partial record SensorEntity : Entity<SensorEntity, EntityState<SensorAttributes>, SensorAttributes>
	{
		public SensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SensorAttributes
	{
		[JsonPropertyName("album_ak.alizandro.smartaudiobookplayer")]
		public string? AlbumAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("android.appInfo")]
		public string? AndroidappInfo { get; init; }

		[JsonPropertyName("android.reduced.images")]
		public bool? Androidreducedimages { get; init; }

		[JsonPropertyName("android.showWhen")]
		public bool? AndroidshowWhen { get; init; }

		[JsonPropertyName("android.text")]
		public string? Androidtext { get; init; }

		[JsonPropertyName("android.title")]
		public string? Androidtitle { get; init; }

		[JsonPropertyName("artist_ak.alizandro.smartaudiobookplayer")]
		public string? ArtistAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("AudioSessions")]
		public IReadOnlyList<object>? AudioSessions { get; init; }

		[JsonPropertyName("BitsPerPixel")]
		public double? BitsPerPixel { get; init; }

		[JsonPropertyName("category")]
		public string? Category { get; init; }

		[JsonPropertyName("channel_id")]
		public string? ChannelId { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("duration_ak.alizandro.smartaudiobookplayer")]
		public double? DurationAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("group_id")]
		public string? GroupId { get; init; }

		[JsonPropertyName("Height")]
		public double? Height { get; init; }

		[JsonPropertyName("hw_disable_ntf_delete_menu")]
		public bool? HwDisableNtfDeleteMenu { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("is_clearable")]
		public bool? IsClearable { get; init; }

		[JsonPropertyName("is_ongoing")]
		public bool? IsOngoing { get; init; }

		[JsonPropertyName("media_id_ak.alizandro.smartaudiobookplayer")]
		public string? MediaIdAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("Name")]
		public string? Name { get; init; }

		[JsonPropertyName("package")]
		public string? Package { get; init; }

		[JsonPropertyName("playback_position_ak.alizandro.smartaudiobookplayer")]
		public double? PlaybackPositionAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("playback_state_ak.alizandro.smartaudiobookplayer")]
		public string? PlaybackStateAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("post_time")]
		public double? PostTime { get; init; }

		[JsonPropertyName("PrimaryDisplay")]
		public bool? PrimaryDisplay { get; init; }

		[JsonPropertyName("Resolution")]
		public string? Resolution { get; init; }

		[JsonPropertyName("title_ak.alizandro.smartaudiobookplayer")]
		public string? TitleAkalizandrosmartaudiobookplayer { get; init; }

		[JsonPropertyName("total_media_session_count")]
		public double? TotalMediaSessionCount { get; init; }

		[JsonPropertyName("Width")]
		public double? Width { get; init; }

		[JsonPropertyName("WorkingArea")]
		public string? WorkingArea { get; init; }

		[JsonPropertyName("WorkingAreaHeight")]
		public double? WorkingAreaHeight { get; init; }

		[JsonPropertyName("WorkingAreaWidth")]
		public double? WorkingAreaWidth { get; init; }
	}

	public partial record SwitchEntity : Entity<SwitchEntity, EntityState<SwitchAttributes>, SwitchAttributes>
	{
		public SwitchEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SwitchEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SwitchAttributes
	{
		[JsonPropertyName("actions")]
		public IReadOnlyList<object>? Actions { get; init; }

		[JsonPropertyName("current_slot")]
		public double? CurrentSlot { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entities")]
		public IReadOnlyList<string>? Entities { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("next_slot")]
		public double? NextSlot { get; init; }

		[JsonPropertyName("next_trigger")]
		public string? NextTrigger { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("tags")]
		public IReadOnlyList<object>? Tags { get; init; }

		[JsonPropertyName("timeslots")]
		public IReadOnlyList<string>? Timeslots { get; init; }

		[JsonPropertyName("weekdays")]
		public IReadOnlyList<string>? Weekdays { get; init; }
	}

	public partial record UpdateEntity : Entity<UpdateEntity, EntityState<UpdateAttributes>, UpdateAttributes>
	{
		public UpdateEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public UpdateEntity(Entity entity) : base(entity)
		{
		}
	}

	public record UpdateAttributes
	{
		[JsonPropertyName("auto_update")]
		public bool? AutoUpdate { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("in_progress")]
		public bool? InProgress { get; init; }

		[JsonPropertyName("installed_version")]
		public string? InstalledVersion { get; init; }

		[JsonPropertyName("latest_version")]
		public string? LatestVersion { get; init; }

		[JsonPropertyName("release_summary")]
		public string? ReleaseSummary { get; init; }

		[JsonPropertyName("release_url")]
		public string? ReleaseUrl { get; init; }

		[JsonPropertyName("skipped_version")]
		public object? SkippedVersion { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public partial record WeatherEntity : Entity<WeatherEntity, EntityState<WeatherAttributes>, WeatherAttributes>
	{
		public WeatherEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public WeatherEntity(Entity entity) : base(entity)
		{
		}
	}

	public record WeatherAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("forecast")]
		public IReadOnlyList<object>? Forecast { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("humidity")]
		public double? Humidity { get; init; }

		[JsonPropertyName("precipitation_unit")]
		public string? PrecipitationUnit { get; init; }

		[JsonPropertyName("pressure")]
		public double? Pressure { get; init; }

		[JsonPropertyName("pressure_unit")]
		public string? PressureUnit { get; init; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; init; }

		[JsonPropertyName("temperature_unit")]
		public string? TemperatureUnit { get; init; }

		[JsonPropertyName("visibility_unit")]
		public string? VisibilityUnit { get; init; }

		[JsonPropertyName("wind_bearing")]
		public double? WindBearing { get; init; }

		[JsonPropertyName("wind_speed")]
		public double? WindSpeed { get; init; }

		[JsonPropertyName("wind_speed_unit")]
		public string? WindSpeedUnit { get; init; }
	}

	public partial record ZoneEntity : Entity<ZoneEntity, EntityState<ZoneAttributes>, ZoneAttributes>
	{
		public ZoneEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ZoneEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ZoneAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("passive")]
		public bool? Passive { get; init; }

		[JsonPropertyName("persons")]
		public IReadOnlyList<string>? Persons { get; init; }

		[JsonPropertyName("radius")]
		public double? Radius { get; init; }
	}

	public interface IServices
	{
		AlarmControlPanelServices AlarmControlPanel { get; }

		AutomationServices Automation { get; }

		ButtonServices Button { get; }

		CameraServices Camera { get; }

		CastServices Cast { get; }

		ClimateServices Climate { get; }

		CloudServices Cloud { get; }

		ConversationServices Conversation { get; }

		CounterServices Counter { get; }

		CoverServices Cover { get; }

		DeviceTrackerServices DeviceTracker { get; }

		FanServices Fan { get; }

		FfmpegServices Ffmpeg { get; }

		FrontendServices Frontend { get; }

		GoogleAssistantServices GoogleAssistant { get; }

		GroupServices Group { get; }

		HassioServices Hassio { get; }

		HistoryStatsServices HistoryStats { get; }

		HomeassistantServices Homeassistant { get; }

		HumidifierServices Humidifier { get; }

		InputBooleanServices InputBoolean { get; }

		InputButtonServices InputButton { get; }

		InputDatetimeServices InputDatetime { get; }

		InputNumberServices InputNumber { get; }

		InputSelectServices InputSelect { get; }

		InputTextServices InputText { get; }

		LightServices Light { get; }

		LockServices Lock { get; }

		LogbookServices Logbook { get; }

		LoggerServices Logger { get; }

		MediaPlayerServices MediaPlayer { get; }

		MqttServices Mqtt { get; }

		NotifyServices Notify { get; }

		NumberServices Number { get; }

		PersistentNotificationServices PersistentNotification { get; }

		PersonServices Person { get; }

		RecorderServices Recorder { get; }

		SceneServices Scene { get; }

		ScheduleServices Schedule { get; }

		SchedulerServices Scheduler { get; }

		ScriptServices Script { get; }

		SelectServices Select { get; }

		ShellCommandServices ShellCommand { get; }

		SirenServices Siren { get; }

		SwitchServices Switch { get; }

		SystemLogServices SystemLog { get; }

		TemplateServices Template { get; }

		TextServices Text { get; }

		TimerServices Timer { get; }

		TtsServices Tts { get; }

		UpdateServices Update { get; }

		UtilityMeterServices UtilityMeter { get; }

		VacuumServices Vacuum { get; }

		WakeOnLanServices WakeOnLan { get; }

		ZoneServices Zone { get; }
	}

	public class Services : IServices
	{
		private readonly IHaContext _haContext;
		public Services(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AlarmControlPanelServices AlarmControlPanel => new(_haContext);
		public AutomationServices Automation => new(_haContext);
		public ButtonServices Button => new(_haContext);
		public CameraServices Camera => new(_haContext);
		public CastServices Cast => new(_haContext);
		public ClimateServices Climate => new(_haContext);
		public CloudServices Cloud => new(_haContext);
		public ConversationServices Conversation => new(_haContext);
		public CounterServices Counter => new(_haContext);
		public CoverServices Cover => new(_haContext);
		public DeviceTrackerServices DeviceTracker => new(_haContext);
		public FanServices Fan => new(_haContext);
		public FfmpegServices Ffmpeg => new(_haContext);
		public FrontendServices Frontend => new(_haContext);
		public GoogleAssistantServices GoogleAssistant => new(_haContext);
		public GroupServices Group => new(_haContext);
		public HassioServices Hassio => new(_haContext);
		public HistoryStatsServices HistoryStats => new(_haContext);
		public HomeassistantServices Homeassistant => new(_haContext);
		public HumidifierServices Humidifier => new(_haContext);
		public InputBooleanServices InputBoolean => new(_haContext);
		public InputButtonServices InputButton => new(_haContext);
		public InputDatetimeServices InputDatetime => new(_haContext);
		public InputNumberServices InputNumber => new(_haContext);
		public InputSelectServices InputSelect => new(_haContext);
		public InputTextServices InputText => new(_haContext);
		public LightServices Light => new(_haContext);
		public LockServices Lock => new(_haContext);
		public LogbookServices Logbook => new(_haContext);
		public LoggerServices Logger => new(_haContext);
		public MediaPlayerServices MediaPlayer => new(_haContext);
		public MqttServices Mqtt => new(_haContext);
		public NotifyServices Notify => new(_haContext);
		public NumberServices Number => new(_haContext);
		public PersistentNotificationServices PersistentNotification => new(_haContext);
		public PersonServices Person => new(_haContext);
		public RecorderServices Recorder => new(_haContext);
		public SceneServices Scene => new(_haContext);
		public ScheduleServices Schedule => new(_haContext);
		public SchedulerServices Scheduler => new(_haContext);
		public ScriptServices Script => new(_haContext);
		public SelectServices Select => new(_haContext);
		public ShellCommandServices ShellCommand => new(_haContext);
		public SirenServices Siren => new(_haContext);
		public SwitchServices Switch => new(_haContext);
		public SystemLogServices SystemLog => new(_haContext);
		public TemplateServices Template => new(_haContext);
		public TextServices Text => new(_haContext);
		public TimerServices Timer => new(_haContext);
		public TtsServices Tts => new(_haContext);
		public UpdateServices Update => new(_haContext);
		public UtilityMeterServices UtilityMeter => new(_haContext);
		public VacuumServices Vacuum => new(_haContext);
		public WakeOnLanServices WakeOnLan => new(_haContext);
		public ZoneServices Zone => new(_haContext);
	}

	public class AlarmControlPanelServices
	{
		private readonly IHaContext _haContext;
		public AlarmControlPanelServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmAway(ServiceTarget target, AlarmControlPanelAlarmArmAwayParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, data);
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm away the alarm control panel with. eg: 1234</param>
		public void AlarmArmAway(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, new AlarmControlPanelAlarmArmAwayParameters{Code = @code});
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmCustomBypass(ServiceTarget target, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, data);
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm custom bypass the alarm control panel with. eg: 1234</param>
		public void AlarmArmCustomBypass(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, new AlarmControlPanelAlarmArmCustomBypassParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmHome(ServiceTarget target, AlarmControlPanelAlarmArmHomeParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, data);
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm home the alarm control panel with. eg: 1234</param>
		public void AlarmArmHome(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, new AlarmControlPanelAlarmArmHomeParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmNight(ServiceTarget target, AlarmControlPanelAlarmArmNightParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, data);
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm night the alarm control panel with. eg: 1234</param>
		public void AlarmArmNight(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, new AlarmControlPanelAlarmArmNightParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmVacation(ServiceTarget target, AlarmControlPanelAlarmArmVacationParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, data);
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm vacation the alarm control panel with. eg: 1234</param>
		public void AlarmArmVacation(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, new AlarmControlPanelAlarmArmVacationParameters{Code = @code});
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmDisarm(ServiceTarget target, AlarmControlPanelAlarmDisarmParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, data);
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to disarm the alarm control panel with. eg: 1234</param>
		public void AlarmDisarm(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, new AlarmControlPanelAlarmDisarmParameters{Code = @code});
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmTrigger(ServiceTarget target, AlarmControlPanelAlarmTriggerParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, data);
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to trigger the alarm control panel with. eg: 1234</param>
		public void AlarmTrigger(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, new AlarmControlPanelAlarmTriggerParameters{Code = @code});
		}
	}

	public record AlarmControlPanelAlarmArmAwayParameters
	{
		///<summary>An optional code to arm away the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmCustomBypassParameters
	{
		///<summary>An optional code to arm custom bypass the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmHomeParameters
	{
		///<summary>An optional code to arm home the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmNightParameters
	{
		///<summary>An optional code to arm night the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmVacationParameters
	{
		///<summary>An optional code to arm vacation the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmDisarmParameters
	{
		///<summary>An optional code to disarm the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmTriggerParameters
	{
		///<summary>An optional code to trigger the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class AutomationServices
	{
		private readonly IHaContext _haContext;
		public AutomationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the automation configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("automation", "reload", null);
		}

		///<summary>Toggle (enable / disable) an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("automation", "toggle", target);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void Trigger(ServiceTarget target, AutomationTriggerParameters data)
		{
			_haContext.CallService("automation", "trigger", target, data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public void Trigger(ServiceTarget target, bool? @skipCondition = null)
		{
			_haContext.CallService("automation", "trigger", target, new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target, AutomationTurnOffParameters data)
		{
			_haContext.CallService("automation", "turn_off", target, data);
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public void TurnOff(ServiceTarget target, bool? @stopActions = null)
		{
			_haContext.CallService("automation", "turn_off", target, new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Enable an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("automation", "turn_on", target);
		}
	}

	public record AutomationTriggerParameters
	{
		///<summary>Whether or not the conditions will be skipped.</summary>
		[JsonPropertyName("skip_condition")]
		public bool? SkipCondition { get; init; }
	}

	public record AutomationTurnOffParameters
	{
		///<summary>Stop currently running actions.</summary>
		[JsonPropertyName("stop_actions")]
		public bool? StopActions { get; init; }
	}

	public class ButtonServices
	{
		private readonly IHaContext _haContext;
		public ButtonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Press the button entity.</summary>
		///<param name="target">The target for this service call</param>
		public void Press(ServiceTarget target)
		{
			_haContext.CallService("button", "press", target);
		}
	}

	public class CameraServices
	{
		private readonly IHaContext _haContext;
		public CameraServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Disable the motion detection in a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void DisableMotionDetection(ServiceTarget target)
		{
			_haContext.CallService("camera", "disable_motion_detection", target);
		}

		///<summary>Enable the motion detection in a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void EnableMotionDetection(ServiceTarget target)
		{
			_haContext.CallService("camera", "enable_motion_detection", target);
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The target for this service call</param>
		public void PlayStream(ServiceTarget target, CameraPlayStreamParameters data)
		{
			_haContext.CallService("camera", "play_stream", target, data);
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mediaPlayer">Name(s) of media player to stream to.</param>
		///<param name="format">Stream format supported by media player.</param>
		public void PlayStream(ServiceTarget target, string @mediaPlayer, object? @format = null)
		{
			_haContext.CallService("camera", "play_stream", target, new CameraPlayStreamParameters{MediaPlayer = @mediaPlayer, Format = @format});
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The target for this service call</param>
		public void Record(ServiceTarget target, CameraRecordParameters data)
		{
			_haContext.CallService("camera", "record", target, data);
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</param>
		///<param name="duration">Target recording length.</param>
		///<param name="lookback">Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</param>
		public void Record(ServiceTarget target, string @filename, long? @duration = null, long? @lookback = null)
		{
			_haContext.CallService("camera", "record", target, new CameraRecordParameters{Filename = @filename, Duration = @duration, Lookback = @lookback});
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void Snapshot(ServiceTarget target, CameraSnapshotParameters data)
		{
			_haContext.CallService("camera", "snapshot", target, data);
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</param>
		public void Snapshot(ServiceTarget target, string @filename)
		{
			_haContext.CallService("camera", "snapshot", target, new CameraSnapshotParameters{Filename = @filename});
		}

		///<summary>Turn off camera.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_off", target);
		}

		///<summary>Turn on camera.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_on", target);
		}
	}

	public record CameraPlayStreamParameters
	{
		///<summary>Name(s) of media player to stream to.</summary>
		[JsonPropertyName("media_player")]
		public string? MediaPlayer { get; init; }

		///<summary>Stream format supported by media player.</summary>
		[JsonPropertyName("format")]
		public object? Format { get; init; }
	}

	public record CameraRecordParameters
	{
		///<summary>Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</summary>
		[JsonPropertyName("filename")]
		public string? Filename { get; init; }

		///<summary>Target recording length.</summary>
		[JsonPropertyName("duration")]
		public long? Duration { get; init; }

		///<summary>Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</summary>
		[JsonPropertyName("lookback")]
		public long? Lookback { get; init; }
	}

	public record CameraSnapshotParameters
	{
		///<summary>Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</summary>
		[JsonPropertyName("filename")]
		public string? Filename { get; init; }
	}

	public class CastServices
	{
		private readonly IHaContext _haContext;
		public CastServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Show a Lovelace view on a Chromecast.</summary>
		public void ShowLovelaceView(CastShowLovelaceViewParameters data)
		{
			_haContext.CallService("cast", "show_lovelace_view", null, data);
		}

		///<summary>Show a Lovelace view on a Chromecast.</summary>
		///<param name="entityId">Media Player entity to show the Lovelace view on.</param>
		///<param name="dashboardPath">The URL path of the Lovelace dashboard to show. eg: lovelace-cast</param>
		///<param name="viewPath">The path of the Lovelace view to show. eg: downstairs</param>
		public void ShowLovelaceView(string @entityId, string @dashboardPath, string? @viewPath = null)
		{
			_haContext.CallService("cast", "show_lovelace_view", null, new CastShowLovelaceViewParameters{EntityId = @entityId, DashboardPath = @dashboardPath, ViewPath = @viewPath});
		}
	}

	public record CastShowLovelaceViewParameters
	{
		///<summary>Media Player entity to show the Lovelace view on.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>The URL path of the Lovelace dashboard to show. eg: lovelace-cast</summary>
		[JsonPropertyName("dashboard_path")]
		public string? DashboardPath { get; init; }

		///<summary>The path of the Lovelace view to show. eg: downstairs</summary>
		[JsonPropertyName("view_path")]
		public string? ViewPath { get; init; }
	}

	public class ClimateServices
	{
		private readonly IHaContext _haContext;
		public ClimateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetAuxHeat(ServiceTarget target, ClimateSetAuxHeatParameters data)
		{
			_haContext.CallService("climate", "set_aux_heat", target, data);
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="auxHeat">New value of auxiliary heater.</param>
		public void SetAuxHeat(ServiceTarget target, bool @auxHeat)
		{
			_haContext.CallService("climate", "set_aux_heat", target, new ClimateSetAuxHeatParameters{AuxHeat = @auxHeat});
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetFanMode(ServiceTarget target, ClimateSetFanModeParameters data)
		{
			_haContext.CallService("climate", "set_fan_mode", target, data);
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="fanMode">New value of fan mode. eg: low</param>
		public void SetFanMode(ServiceTarget target, string @fanMode)
		{
			_haContext.CallService("climate", "set_fan_mode", target, new ClimateSetFanModeParameters{FanMode = @fanMode});
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHumidity(ServiceTarget target, ClimateSetHumidityParameters data)
		{
			_haContext.CallService("climate", "set_humidity", target, data);
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="humidity">New target humidity for climate device.</param>
		public void SetHumidity(ServiceTarget target, long @humidity)
		{
			_haContext.CallService("climate", "set_humidity", target, new ClimateSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHvacMode(ServiceTarget target, ClimateSetHvacModeParameters data)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, data);
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="hvacMode">New value of operation mode.</param>
		public void SetHvacMode(ServiceTarget target, object? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, new ClimateSetHvacModeParameters{HvacMode = @hvacMode});
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPresetMode(ServiceTarget target, ClimateSetPresetModeParameters data)
		{
			_haContext.CallService("climate", "set_preset_mode", target, data);
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="presetMode">New value of preset mode. eg: away</param>
		public void SetPresetMode(ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("climate", "set_preset_mode", target, new ClimateSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetSwingMode(ServiceTarget target, ClimateSetSwingModeParameters data)
		{
			_haContext.CallService("climate", "set_swing_mode", target, data);
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="swingMode">New value of swing mode. eg: horizontal</param>
		public void SetSwingMode(ServiceTarget target, string @swingMode)
		{
			_haContext.CallService("climate", "set_swing_mode", target, new ClimateSetSwingModeParameters{SwingMode = @swingMode});
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetTemperature(ServiceTarget target, ClimateSetTemperatureParameters data)
		{
			_haContext.CallService("climate", "set_temperature", target, data);
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="temperature">New target temperature for HVAC.</param>
		///<param name="targetTempHigh">New target high temperature for HVAC.</param>
		///<param name="targetTempLow">New target low temperature for HVAC.</param>
		///<param name="hvacMode">HVAC operation mode to set temperature to.</param>
		public void SetTemperature(ServiceTarget target, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, object? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_temperature", target, new ClimateSetTemperatureParameters{Temperature = @temperature, TargetTempHigh = @targetTempHigh, TargetTempLow = @targetTempLow, HvacMode = @hvacMode});
		}

		///<summary>Turn climate device off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_off", target);
		}

		///<summary>Turn climate device on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_on", target);
		}
	}

	public record ClimateSetAuxHeatParameters
	{
		///<summary>New value of auxiliary heater.</summary>
		[JsonPropertyName("aux_heat")]
		public bool? AuxHeat { get; init; }
	}

	public record ClimateSetFanModeParameters
	{
		///<summary>New value of fan mode. eg: low</summary>
		[JsonPropertyName("fan_mode")]
		public string? FanMode { get; init; }
	}

	public record ClimateSetHumidityParameters
	{
		///<summary>New target humidity for climate device.</summary>
		[JsonPropertyName("humidity")]
		public long? Humidity { get; init; }
	}

	public record ClimateSetHvacModeParameters
	{
		///<summary>New value of operation mode.</summary>
		[JsonPropertyName("hvac_mode")]
		public object? HvacMode { get; init; }
	}

	public record ClimateSetPresetModeParameters
	{
		///<summary>New value of preset mode. eg: away</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public record ClimateSetSwingModeParameters
	{
		///<summary>New value of swing mode. eg: horizontal</summary>
		[JsonPropertyName("swing_mode")]
		public string? SwingMode { get; init; }
	}

	public record ClimateSetTemperatureParameters
	{
		///<summary>New target temperature for HVAC.</summary>
		[JsonPropertyName("temperature")]
		public double? Temperature { get; init; }

		///<summary>New target high temperature for HVAC.</summary>
		[JsonPropertyName("target_temp_high")]
		public double? TargetTempHigh { get; init; }

		///<summary>New target low temperature for HVAC.</summary>
		[JsonPropertyName("target_temp_low")]
		public double? TargetTempLow { get; init; }

		///<summary>HVAC operation mode to set temperature to.</summary>
		[JsonPropertyName("hvac_mode")]
		public object? HvacMode { get; init; }
	}

	public class CloudServices
	{
		private readonly IHaContext _haContext;
		public CloudServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Make instance UI available outside over NabuCasa cloud</summary>
		public void RemoteConnect()
		{
			_haContext.CallService("cloud", "remote_connect", null);
		}

		///<summary>Disconnect UI from NabuCasa cloud</summary>
		public void RemoteDisconnect()
		{
			_haContext.CallService("cloud", "remote_disconnect", null);
		}
	}

	public class ConversationServices
	{
		private readonly IHaContext _haContext;
		public ConversationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Launch a conversation from a transcribed text.</summary>
		public void Process(ConversationProcessParameters data)
		{
			_haContext.CallService("conversation", "process", null, data);
		}

		///<summary>Launch a conversation from a transcribed text.</summary>
		///<param name="text">Transcribed text eg: Turn all lights on</param>
		///<param name="language">Language of text. Defaults to server language eg: NL</param>
		///<param name="agentId">Assist engine to process your request eg: homeassistant</param>
		public void Process(string? @text = null, string? @language = null, string? @agentId = null)
		{
			_haContext.CallService("conversation", "process", null, new ConversationProcessParameters{Text = @text, Language = @language, AgentId = @agentId});
		}

		public void Reload()
		{
			_haContext.CallService("conversation", "reload", null);
		}
	}

	public record ConversationProcessParameters
	{
		///<summary>Transcribed text eg: Turn all lights on</summary>
		[JsonPropertyName("text")]
		public string? Text { get; init; }

		///<summary>Language of text. Defaults to server language eg: NL</summary>
		[JsonPropertyName("language")]
		public string? Language { get; init; }

		///<summary>Assist engine to process your request eg: homeassistant</summary>
		[JsonPropertyName("agent_id")]
		public string? AgentId { get; init; }
	}

	public class CounterServices
	{
		private readonly IHaContext _haContext;
		public CounterServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Change counter parameters.</summary>
		///<param name="target">The target for this service call</param>
		public void Configure(ServiceTarget target, CounterConfigureParameters data)
		{
			_haContext.CallService("counter", "configure", target, data);
		}

		///<summary>Change counter parameters.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="minimum">New minimum value for the counter or None to remove minimum.</param>
		///<param name="maximum">New maximum value for the counter or None to remove maximum.</param>
		///<param name="step">New value for step.</param>
		///<param name="initial">New value for initial.</param>
		///<param name="value">New state value.</param>
		public void Configure(ServiceTarget target, long? @minimum = null, long? @maximum = null, long? @step = null, long? @initial = null, long? @value = null)
		{
			_haContext.CallService("counter", "configure", target, new CounterConfigureParameters{Minimum = @minimum, Maximum = @maximum, Step = @step, Initial = @initial, Value = @value});
		}

		///<summary>Decrement a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Decrement(ServiceTarget target)
		{
			_haContext.CallService("counter", "decrement", target);
		}

		///<summary>Increment a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Increment(ServiceTarget target)
		{
			_haContext.CallService("counter", "increment", target);
		}

		///<summary>Reset a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Reset(ServiceTarget target)
		{
			_haContext.CallService("counter", "reset", target);
		}
	}

	public record CounterConfigureParameters
	{
		///<summary>New minimum value for the counter or None to remove minimum.</summary>
		[JsonPropertyName("minimum")]
		public long? Minimum { get; init; }

		///<summary>New maximum value for the counter or None to remove maximum.</summary>
		[JsonPropertyName("maximum")]
		public long? Maximum { get; init; }

		///<summary>New value for step.</summary>
		[JsonPropertyName("step")]
		public long? Step { get; init; }

		///<summary>New value for initial.</summary>
		[JsonPropertyName("initial")]
		public long? Initial { get; init; }

		///<summary>New state value.</summary>
		[JsonPropertyName("value")]
		public long? Value { get; init; }
	}

	public class CoverServices
	{
		private readonly IHaContext _haContext;
		public CoverServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Close all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void CloseCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover", target);
		}

		///<summary>Close all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void CloseCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover_tilt", target);
		}

		///<summary>Open all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void OpenCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover", target);
		}

		///<summary>Open all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void OpenCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover_tilt", target);
		}

		///<summary>Move to specific position all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void SetCoverPosition(ServiceTarget target, CoverSetCoverPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_position", target, data);
		}

		///<summary>Move to specific position all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="position">Position of the cover</param>
		public void SetCoverPosition(ServiceTarget target, long @position)
		{
			_haContext.CallService("cover", "set_cover_position", target, new CoverSetCoverPositionParameters{Position = @position});
		}

		///<summary>Move to specific position all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void SetCoverTiltPosition(ServiceTarget target, CoverSetCoverTiltPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, data);
		}

		///<summary>Move to specific position all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="tiltPosition">Tilt position of the cover.</param>
		public void SetCoverTiltPosition(ServiceTarget target, long @tiltPosition)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, new CoverSetCoverTiltPositionParameters{TiltPosition = @tiltPosition});
		}

		///<summary>Stop all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void StopCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover", target);
		}

		///<summary>Stop all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void StopCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover_tilt", target);
		}

		///<summary>Toggle a cover open/closed.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle", target);
		}

		///<summary>Toggle a cover tilt open/closed.</summary>
		///<param name="target">The target for this service call</param>
		public void ToggleCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle_cover_tilt", target);
		}
	}

	public record CoverSetCoverPositionParameters
	{
		///<summary>Position of the cover</summary>
		[JsonPropertyName("position")]
		public long? Position { get; init; }
	}

	public record CoverSetCoverTiltPositionParameters
	{
		///<summary>Tilt position of the cover.</summary>
		[JsonPropertyName("tilt_position")]
		public long? TiltPosition { get; init; }
	}

	public class DeviceTrackerServices
	{
		private readonly IHaContext _haContext;
		public DeviceTrackerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Control tracked device.</summary>
		public void See(DeviceTrackerSeeParameters data)
		{
			_haContext.CallService("device_tracker", "see", null, data);
		}

		///<summary>Control tracked device.</summary>
		///<param name="mac">MAC address of device eg: FF:FF:FF:FF:FF:FF</param>
		///<param name="devId">Id of device (find id in known_devices.yaml). eg: phonedave</param>
		///<param name="hostName">Hostname of device eg: Dave</param>
		///<param name="locationName">Name of location where device is located (not_home is away). eg: home</param>
		///<param name="gps">GPS coordinates where device is located (latitude, longitude). eg: [51.509802, -0.086692]</param>
		///<param name="gpsAccuracy">Accuracy of GPS coordinates.</param>
		///<param name="battery">Battery level of device.</param>
		public void See(string? @mac = null, string? @devId = null, string? @hostName = null, string? @locationName = null, object? @gps = null, long? @gpsAccuracy = null, long? @battery = null)
		{
			_haContext.CallService("device_tracker", "see", null, new DeviceTrackerSeeParameters{Mac = @mac, DevId = @devId, HostName = @hostName, LocationName = @locationName, Gps = @gps, GpsAccuracy = @gpsAccuracy, Battery = @battery});
		}
	}

	public record DeviceTrackerSeeParameters
	{
		///<summary>MAC address of device eg: FF:FF:FF:FF:FF:FF</summary>
		[JsonPropertyName("mac")]
		public string? Mac { get; init; }

		///<summary>Id of device (find id in known_devices.yaml). eg: phonedave</summary>
		[JsonPropertyName("dev_id")]
		public string? DevId { get; init; }

		///<summary>Hostname of device eg: Dave</summary>
		[JsonPropertyName("host_name")]
		public string? HostName { get; init; }

		///<summary>Name of location where device is located (not_home is away). eg: home</summary>
		[JsonPropertyName("location_name")]
		public string? LocationName { get; init; }

		///<summary>GPS coordinates where device is located (latitude, longitude). eg: [51.509802, -0.086692]</summary>
		[JsonPropertyName("gps")]
		public object? Gps { get; init; }

		///<summary>Accuracy of GPS coordinates.</summary>
		[JsonPropertyName("gps_accuracy")]
		public long? GpsAccuracy { get; init; }

		///<summary>Battery level of device.</summary>
		[JsonPropertyName("battery")]
		public long? Battery { get; init; }
	}

	public class FanServices
	{
		private readonly IHaContext _haContext;
		public FanServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		public void DecreaseSpeed(ServiceTarget target, FanDecreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "decrease_speed", target, data);
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentageStep">Decrease speed by a percentage.</param>
		public void DecreaseSpeed(ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "decrease_speed", target, new FanDecreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		public void IncreaseSpeed(ServiceTarget target, FanIncreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "increase_speed", target, data);
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentageStep">Increase speed by a percentage.</param>
		public void IncreaseSpeed(ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "increase_speed", target, new FanIncreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The target for this service call</param>
		public void Oscillate(ServiceTarget target, FanOscillateParameters data)
		{
			_haContext.CallService("fan", "oscillate", target, data);
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="oscillating">Flag to turn on/off oscillation.</param>
		public void Oscillate(ServiceTarget target, bool @oscillating)
		{
			_haContext.CallService("fan", "oscillate", target, new FanOscillateParameters{Oscillating = @oscillating});
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The target for this service call</param>
		public void SetDirection(ServiceTarget target, FanSetDirectionParameters data)
		{
			_haContext.CallService("fan", "set_direction", target, data);
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="direction">The direction to rotate.</param>
		public void SetDirection(ServiceTarget target, object @direction)
		{
			_haContext.CallService("fan", "set_direction", target, new FanSetDirectionParameters{Direction = @direction});
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPercentage(ServiceTarget target, FanSetPercentageParameters data)
		{
			_haContext.CallService("fan", "set_percentage", target, data);
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentage">Percentage speed setting.</param>
		public void SetPercentage(ServiceTarget target, long @percentage)
		{
			_haContext.CallService("fan", "set_percentage", target, new FanSetPercentageParameters{Percentage = @percentage});
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPresetMode(ServiceTarget target, FanSetPresetModeParameters data)
		{
			_haContext.CallService("fan", "set_preset_mode", target, data);
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="presetMode">New value of preset mode. eg: auto</param>
		public void SetPresetMode(ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("fan", "set_preset_mode", target, new FanSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Toggle the fan on/off.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("fan", "toggle", target);
		}

		///<summary>Turn fan off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("fan", "turn_off", target);
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, FanTurnOnParameters data)
		{
			_haContext.CallService("fan", "turn_on", target, data);
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="speed">Speed setting. eg: high</param>
		///<param name="percentage">Percentage speed setting.</param>
		///<param name="presetMode">Preset mode setting. eg: auto</param>
		public void TurnOn(ServiceTarget target, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			_haContext.CallService("fan", "turn_on", target, new FanTurnOnParameters{Speed = @speed, Percentage = @percentage, PresetMode = @presetMode});
		}
	}

	public record FanDecreaseSpeedParameters
	{
		///<summary>Decrease speed by a percentage.</summary>
		[JsonPropertyName("percentage_step")]
		public long? PercentageStep { get; init; }
	}

	public record FanIncreaseSpeedParameters
	{
		///<summary>Increase speed by a percentage.</summary>
		[JsonPropertyName("percentage_step")]
		public long? PercentageStep { get; init; }
	}

	public record FanOscillateParameters
	{
		///<summary>Flag to turn on/off oscillation.</summary>
		[JsonPropertyName("oscillating")]
		public bool? Oscillating { get; init; }
	}

	public record FanSetDirectionParameters
	{
		///<summary>The direction to rotate.</summary>
		[JsonPropertyName("direction")]
		public object? Direction { get; init; }
	}

	public record FanSetPercentageParameters
	{
		///<summary>Percentage speed setting.</summary>
		[JsonPropertyName("percentage")]
		public long? Percentage { get; init; }
	}

	public record FanSetPresetModeParameters
	{
		///<summary>New value of preset mode. eg: auto</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public record FanTurnOnParameters
	{
		///<summary>Speed setting. eg: high</summary>
		[JsonPropertyName("speed")]
		public string? Speed { get; init; }

		///<summary>Percentage speed setting.</summary>
		[JsonPropertyName("percentage")]
		public long? Percentage { get; init; }

		///<summary>Preset mode setting. eg: auto</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public class FfmpegServices
	{
		private readonly IHaContext _haContext;
		public FfmpegServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send a restart command to a ffmpeg based sensor.</summary>
		public void Restart(FfmpegRestartParameters data)
		{
			_haContext.CallService("ffmpeg", "restart", null, data);
		}

		///<summary>Send a restart command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will restart. Platform dependent.</param>
		public void Restart(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "restart", null, new FfmpegRestartParameters{EntityId = @entityId});
		}

		///<summary>Send a start command to a ffmpeg based sensor.</summary>
		public void Start(FfmpegStartParameters data)
		{
			_haContext.CallService("ffmpeg", "start", null, data);
		}

		///<summary>Send a start command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will start. Platform dependent.</param>
		public void Start(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "start", null, new FfmpegStartParameters{EntityId = @entityId});
		}

		///<summary>Send a stop command to a ffmpeg based sensor.</summary>
		public void Stop(FfmpegStopParameters data)
		{
			_haContext.CallService("ffmpeg", "stop", null, data);
		}

		///<summary>Send a stop command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will stop. Platform dependent.</param>
		public void Stop(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "stop", null, new FfmpegStopParameters{EntityId = @entityId});
		}
	}

	public record FfmpegRestartParameters
	{
		///<summary>Name of entity that will restart. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStartParameters
	{
		///<summary>Name of entity that will start. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStopParameters
	{
		///<summary>Name of entity that will stop. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public class FrontendServices
	{
		private readonly IHaContext _haContext;
		public FrontendServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload themes from YAML configuration.</summary>
		public void ReloadThemes()
		{
			_haContext.CallService("frontend", "reload_themes", null);
		}

		///<summary>Set a theme unless the client selected per-device theme.</summary>
		public void SetTheme(FrontendSetThemeParameters data)
		{
			_haContext.CallService("frontend", "set_theme", null, data);
		}

		///<summary>Set a theme unless the client selected per-device theme.</summary>
		///<param name="name">Name of a predefined theme eg: default</param>
		///<param name="mode">The mode the theme is for.</param>
		public void SetTheme(object @name, object? @mode = null)
		{
			_haContext.CallService("frontend", "set_theme", null, new FrontendSetThemeParameters{Name = @name, Mode = @mode});
		}
	}

	public record FrontendSetThemeParameters
	{
		///<summary>Name of a predefined theme eg: default</summary>
		[JsonPropertyName("name")]
		public object? Name { get; init; }

		///<summary>The mode the theme is for.</summary>
		[JsonPropertyName("mode")]
		public object? Mode { get; init; }
	}

	public class GoogleAssistantServices
	{
		private readonly IHaContext _haContext;
		public GoogleAssistantServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send a request_sync command to Google.</summary>
		public void RequestSync(GoogleAssistantRequestSyncParameters data)
		{
			_haContext.CallService("google_assistant", "request_sync", null, data);
		}

		///<summary>Send a request_sync command to Google.</summary>
		///<param name="agentUserId">Only needed for automations. Specific Home Assistant user id (not username, ID in configuration > users > under username) to sync with Google Assistant. Do not need when you call this service through Home Assistant front end or API. Used in automation script or other place where context.user_id is missing.</param>
		public void RequestSync(string? @agentUserId = null)
		{
			_haContext.CallService("google_assistant", "request_sync", null, new GoogleAssistantRequestSyncParameters{AgentUserId = @agentUserId});
		}
	}

	public record GoogleAssistantRequestSyncParameters
	{
		///<summary>Only needed for automations. Specific Home Assistant user id (not username, ID in configuration > users > under username) to sync with Google Assistant. Do not need when you call this service through Home Assistant front end or API. Used in automation script or other place where context.user_id is missing.</summary>
		[JsonPropertyName("agent_user_id")]
		public string? AgentUserId { get; init; }
	}

	public class GroupServices
	{
		private readonly IHaContext _haContext;
		public GroupServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload group configuration, entities, and notify services.</summary>
		public void Reload()
		{
			_haContext.CallService("group", "reload", null);
		}

		///<summary>Remove a user group.</summary>
		public void Remove(GroupRemoveParameters data)
		{
			_haContext.CallService("group", "remove", null, data);
		}

		///<summary>Remove a user group.</summary>
		///<param name="objectId">Group id and part of entity id. eg: test_group</param>
		public void Remove(object @objectId)
		{
			_haContext.CallService("group", "remove", null, new GroupRemoveParameters{ObjectId = @objectId});
		}

		///<summary>Create/Update a user group.</summary>
		public void Set(GroupSetParameters data)
		{
			_haContext.CallService("group", "set", null, data);
		}

		///<summary>Create/Update a user group.</summary>
		///<param name="objectId">Group id and part of entity id. eg: test_group</param>
		///<param name="name">Name of group eg: My test group</param>
		///<param name="icon">Name of icon for the group. eg: mdi:camera</param>
		///<param name="entities">List of all members in the group. Not compatible with 'delta'. eg: domain.entity_id1, domain.entity_id2</param>
		///<param name="addEntities">List of members that will change on group listening. eg: domain.entity_id1, domain.entity_id2</param>
		///<param name="removeEntities">List of members that will be removed from group listening. eg: domain.entity_id1, domain.entity_id2</param>
		///<param name="all">Enable this option if the group should only turn on when all entities are on.</param>
		public void Set(string @objectId, string? @name = null, object? @icon = null, object? @entities = null, object? @addEntities = null, object? @removeEntities = null, bool? @all = null)
		{
			_haContext.CallService("group", "set", null, new GroupSetParameters{ObjectId = @objectId, Name = @name, Icon = @icon, Entities = @entities, AddEntities = @addEntities, RemoveEntities = @removeEntities, All = @all});
		}
	}

	public record GroupRemoveParameters
	{
		///<summary>Group id and part of entity id. eg: test_group</summary>
		[JsonPropertyName("object_id")]
		public object? ObjectId { get; init; }
	}

	public record GroupSetParameters
	{
		///<summary>Group id and part of entity id. eg: test_group</summary>
		[JsonPropertyName("object_id")]
		public string? ObjectId { get; init; }

		///<summary>Name of group eg: My test group</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Name of icon for the group. eg: mdi:camera</summary>
		[JsonPropertyName("icon")]
		public object? Icon { get; init; }

		///<summary>List of all members in the group. Not compatible with 'delta'. eg: domain.entity_id1, domain.entity_id2</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>List of members that will change on group listening. eg: domain.entity_id1, domain.entity_id2</summary>
		[JsonPropertyName("add_entities")]
		public object? AddEntities { get; init; }

		///<summary>List of members that will be removed from group listening. eg: domain.entity_id1, domain.entity_id2</summary>
		[JsonPropertyName("remove_entities")]
		public object? RemoveEntities { get; init; }

		///<summary>Enable this option if the group should only turn on when all entities are on.</summary>
		[JsonPropertyName("all")]
		public bool? All { get; init; }
	}

	public class HassioServices
	{
		private readonly IHaContext _haContext;
		public HassioServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Restart add-on.</summary>
		public void AddonRestart(HassioAddonRestartParameters data)
		{
			_haContext.CallService("hassio", "addon_restart", null, data);
		}

		///<summary>Restart add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonRestart(string @addon)
		{
			_haContext.CallService("hassio", "addon_restart", null, new HassioAddonRestartParameters{Addon = @addon});
		}

		///<summary>Start add-on.</summary>
		public void AddonStart(HassioAddonStartParameters data)
		{
			_haContext.CallService("hassio", "addon_start", null, data);
		}

		///<summary>Start add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStart(string @addon)
		{
			_haContext.CallService("hassio", "addon_start", null, new HassioAddonStartParameters{Addon = @addon});
		}

		///<summary>Write data to add-on stdin.</summary>
		public void AddonStdin(HassioAddonStdinParameters data)
		{
			_haContext.CallService("hassio", "addon_stdin", null, data);
		}

		///<summary>Write data to add-on stdin.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStdin(string @addon)
		{
			_haContext.CallService("hassio", "addon_stdin", null, new HassioAddonStdinParameters{Addon = @addon});
		}

		///<summary>Stop add-on.</summary>
		public void AddonStop(HassioAddonStopParameters data)
		{
			_haContext.CallService("hassio", "addon_stop", null, data);
		}

		///<summary>Stop add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStop(string @addon)
		{
			_haContext.CallService("hassio", "addon_stop", null, new HassioAddonStopParameters{Addon = @addon});
		}

		///<summary>Update add-on. This service should be used with caution since add-on updates can contain breaking changes. It is highly recommended that you review release notes/change logs before updating an add-on.</summary>
		public void AddonUpdate(HassioAddonUpdateParameters data)
		{
			_haContext.CallService("hassio", "addon_update", null, data);
		}

		///<summary>Update add-on. This service should be used with caution since add-on updates can contain breaking changes. It is highly recommended that you review release notes/change logs before updating an add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonUpdate(string @addon)
		{
			_haContext.CallService("hassio", "addon_update", null, new HassioAddonUpdateParameters{Addon = @addon});
		}

		///<summary>Create a full backup.</summary>
		public void BackupFull(HassioBackupFullParameters data)
		{
			_haContext.CallService("hassio", "backup_full", null, data);
		}

		///<summary>Create a full backup.</summary>
		///<param name="name">Optional (default = current date and time). eg: Backup 1</param>
		///<param name="password">Optional password. eg: password</param>
		///<param name="compressed">Use compressed archives</param>
		public void BackupFull(string? @name = null, string? @password = null, bool? @compressed = null)
		{
			_haContext.CallService("hassio", "backup_full", null, new HassioBackupFullParameters{Name = @name, Password = @password, Compressed = @compressed});
		}

		///<summary>Create a partial backup.</summary>
		public void BackupPartial(HassioBackupPartialParameters data)
		{
			_haContext.CallService("hassio", "backup_partial", null, data);
		}

		///<summary>Create a partial backup.</summary>
		///<param name="homeassistant">Backup Home Assistant settings</param>
		///<param name="addons">Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</param>
		///<param name="folders">Optional list of directories. eg: ["homeassistant","share"]</param>
		///<param name="name">Optional (default = current date and time). eg: Partial backup 1</param>
		///<param name="password">Optional password. eg: password</param>
		///<param name="compressed">Use compressed archives</param>
		public void BackupPartial(bool? @homeassistant = null, object? @addons = null, object? @folders = null, string? @name = null, string? @password = null, bool? @compressed = null)
		{
			_haContext.CallService("hassio", "backup_partial", null, new HassioBackupPartialParameters{Homeassistant = @homeassistant, Addons = @addons, Folders = @folders, Name = @name, Password = @password, Compressed = @compressed});
		}

		///<summary>Reboot the host system.</summary>
		public void HostReboot()
		{
			_haContext.CallService("hassio", "host_reboot", null);
		}

		///<summary>Poweroff the host system.</summary>
		public void HostShutdown()
		{
			_haContext.CallService("hassio", "host_shutdown", null);
		}

		///<summary>Restore from full backup.</summary>
		public void RestoreFull(HassioRestoreFullParameters data)
		{
			_haContext.CallService("hassio", "restore_full", null, data);
		}

		///<summary>Restore from full backup.</summary>
		///<param name="slug">Slug of backup to restore from.</param>
		///<param name="password">Optional password. eg: password</param>
		public void RestoreFull(string @slug, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_full", null, new HassioRestoreFullParameters{Slug = @slug, Password = @password});
		}

		///<summary>Restore from partial backup.</summary>
		public void RestorePartial(HassioRestorePartialParameters data)
		{
			_haContext.CallService("hassio", "restore_partial", null, data);
		}

		///<summary>Restore from partial backup.</summary>
		///<param name="slug">Slug of backup to restore from.</param>
		///<param name="homeassistant">Restore Home Assistant</param>
		///<param name="folders">Optional list of directories. eg: ["homeassistant","share"]</param>
		///<param name="addons">Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</param>
		///<param name="password">Optional password. eg: password</param>
		public void RestorePartial(string @slug, bool? @homeassistant = null, object? @folders = null, object? @addons = null, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_partial", null, new HassioRestorePartialParameters{Slug = @slug, Homeassistant = @homeassistant, Folders = @folders, Addons = @addons, Password = @password});
		}
	}

	public record HassioAddonRestartParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStartParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStdinParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStopParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonUpdateParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioBackupFullParameters
	{
		///<summary>Optional (default = current date and time). eg: Backup 1</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }

		///<summary>Use compressed archives</summary>
		[JsonPropertyName("compressed")]
		public bool? Compressed { get; init; }
	}

	public record HassioBackupPartialParameters
	{
		///<summary>Backup Home Assistant settings</summary>
		[JsonPropertyName("homeassistant")]
		public bool? Homeassistant { get; init; }

		///<summary>Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</summary>
		[JsonPropertyName("addons")]
		public object? Addons { get; init; }

		///<summary>Optional list of directories. eg: ["homeassistant","share"]</summary>
		[JsonPropertyName("folders")]
		public object? Folders { get; init; }

		///<summary>Optional (default = current date and time). eg: Partial backup 1</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }

		///<summary>Use compressed archives</summary>
		[JsonPropertyName("compressed")]
		public bool? Compressed { get; init; }
	}

	public record HassioRestoreFullParameters
	{
		///<summary>Slug of backup to restore from.</summary>
		[JsonPropertyName("slug")]
		public string? Slug { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public record HassioRestorePartialParameters
	{
		///<summary>Slug of backup to restore from.</summary>
		[JsonPropertyName("slug")]
		public string? Slug { get; init; }

		///<summary>Restore Home Assistant</summary>
		[JsonPropertyName("homeassistant")]
		public bool? Homeassistant { get; init; }

		///<summary>Optional list of directories. eg: ["homeassistant","share"]</summary>
		[JsonPropertyName("folders")]
		public object? Folders { get; init; }

		///<summary>Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</summary>
		[JsonPropertyName("addons")]
		public object? Addons { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public class HistoryStatsServices
	{
		private readonly IHaContext _haContext;
		public HistoryStatsServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload all history_stats entities.</summary>
		public void Reload()
		{
			_haContext.CallService("history_stats", "reload", null);
		}
	}

	public class HomeassistantServices
	{
		private readonly IHaContext _haContext;
		public HomeassistantServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Check the Home Assistant configuration files for errors. Errors will be displayed in the Home Assistant log.</summary>
		public void CheckConfig()
		{
			_haContext.CallService("homeassistant", "check_config", null);
		}

		public void ReloadAll()
		{
			_haContext.CallService("homeassistant", "reload_all", null);
		}

		///<summary>Reload a config entry that matches a target.</summary>
		///<param name="target">The target for this service call</param>
		public void ReloadConfigEntry(ServiceTarget target, HomeassistantReloadConfigEntryParameters data)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, data);
		}

		///<summary>Reload a config entry that matches a target.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entryId">A configuration entry id eg: 8955375327824e14ba89e4b29cc3ec9a</param>
		public void ReloadConfigEntry(ServiceTarget target, string? @entryId = null)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, new HomeassistantReloadConfigEntryParameters{EntryId = @entryId});
		}

		///<summary>Reload the core configuration.</summary>
		public void ReloadCoreConfig()
		{
			_haContext.CallService("homeassistant", "reload_core_config", null);
		}

		///<summary>Restart the Home Assistant service.</summary>
		public void Restart()
		{
			_haContext.CallService("homeassistant", "restart", null);
		}

		///<summary>Save the persistent states (for entities derived from RestoreEntity) immediately. Maintain the normal periodic saving interval.</summary>
		public void SavePersistentStates()
		{
			_haContext.CallService("homeassistant", "save_persistent_states", null);
		}

		///<summary>Update the Home Assistant location.</summary>
		public void SetLocation(HomeassistantSetLocationParameters data)
		{
			_haContext.CallService("homeassistant", "set_location", null, data);
		}

		///<summary>Update the Home Assistant location.</summary>
		///<param name="latitude">Latitude of your location. eg: 32.87336</param>
		///<param name="longitude">Longitude of your location. eg: 117.22743</param>
		public void SetLocation(string @latitude, string @longitude)
		{
			_haContext.CallService("homeassistant", "set_location", null, new HomeassistantSetLocationParameters{Latitude = @latitude, Longitude = @longitude});
		}

		///<summary>Stop the Home Assistant service.</summary>
		public void Stop()
		{
			_haContext.CallService("homeassistant", "stop", null);
		}

		///<summary>Generic service to toggle devices on/off under any domain</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "toggle", target);
		}

		///<summary>Generic service to turn devices off under any domain.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_off", target);
		}

		///<summary>Generic service to turn devices on under any domain.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_on", target);
		}

		///<summary>Force one or more entities to update its data</summary>
		///<param name="target">The target for this service call</param>
		public void UpdateEntity(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "update_entity", target);
		}
	}

	public record HomeassistantReloadConfigEntryParameters
	{
		///<summary>A configuration entry id eg: 8955375327824e14ba89e4b29cc3ec9a</summary>
		[JsonPropertyName("entry_id")]
		public string? EntryId { get; init; }
	}

	public record HomeassistantSetLocationParameters
	{
		///<summary>Latitude of your location. eg: 32.87336</summary>
		[JsonPropertyName("latitude")]
		public string? Latitude { get; init; }

		///<summary>Longitude of your location. eg: 117.22743</summary>
		[JsonPropertyName("longitude")]
		public string? Longitude { get; init; }
	}

	public class HumidifierServices
	{
		private readonly IHaContext _haContext;
		public HumidifierServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set target humidity of humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHumidity(ServiceTarget target, HumidifierSetHumidityParameters data)
		{
			_haContext.CallService("humidifier", "set_humidity", target, data);
		}

		///<summary>Set target humidity of humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="humidity">New target humidity for humidifier device.</param>
		public void SetHumidity(ServiceTarget target, long @humidity)
		{
			_haContext.CallService("humidifier", "set_humidity", target, new HumidifierSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set mode for humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetMode(ServiceTarget target, HumidifierSetModeParameters data)
		{
			_haContext.CallService("humidifier", "set_mode", target, data);
		}

		///<summary>Set mode for humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mode">New mode eg: away</param>
		public void SetMode(ServiceTarget target, string @mode)
		{
			_haContext.CallService("humidifier", "set_mode", target, new HumidifierSetModeParameters{Mode = @mode});
		}

		///<summary>Toggles a humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "toggle", target);
		}

		///<summary>Turn humidifier device off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "turn_off", target);
		}

		///<summary>Turn humidifier device on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "turn_on", target);
		}
	}

	public record HumidifierSetHumidityParameters
	{
		///<summary>New target humidity for humidifier device.</summary>
		[JsonPropertyName("humidity")]
		public long? Humidity { get; init; }
	}

	public record HumidifierSetModeParameters
	{
		///<summary>New mode eg: away</summary>
		[JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public class InputBooleanServices
	{
		private readonly IHaContext _haContext;
		public InputBooleanServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_boolean configuration</summary>
		public void Reload()
		{
			_haContext.CallService("input_boolean", "reload", null);
		}

		///<summary>Toggle an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "toggle", target);
		}

		///<summary>Turn off an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_off", target);
		}

		///<summary>Turn on an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_on", target);
		}
	}

	public class InputButtonServices
	{
		private readonly IHaContext _haContext;
		public InputButtonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Press the input button entity.</summary>
		///<param name="target">The target for this service call</param>
		public void Press(ServiceTarget target)
		{
			_haContext.CallService("input_button", "press", target);
		}

		public void Reload()
		{
			_haContext.CallService("input_button", "reload", null);
		}
	}

	public class InputDatetimeServices
	{
		private readonly IHaContext _haContext;
		public InputDatetimeServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_datetime configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_datetime", "reload", null);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The target for this service call</param>
		public void SetDatetime(ServiceTarget target, InputDatetimeSetDatetimeParameters data)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, data);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="date">The target date the entity should be set to. eg: "2019-04-20"</param>
		///<param name="time">The target time the entity should be set to. eg: "05:04:20"</param>
		///<param name="datetime">The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</param>
		///<param name="timestamp">The target date & time the entity should be set to as expressed by a UNIX timestamp.</param>
		public void SetDatetime(ServiceTarget target, string? @date = null, DateTime? @time = null, string? @datetime = null, long? @timestamp = null)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, new InputDatetimeSetDatetimeParameters{Date = @date, Time = @time, Datetime = @datetime, Timestamp = @timestamp});
		}
	}

	public record InputDatetimeSetDatetimeParameters
	{
		///<summary>The target date the entity should be set to. eg: "2019-04-20"</summary>
		[JsonPropertyName("date")]
		public string? Date { get; init; }

		///<summary>The target time the entity should be set to. eg: "05:04:20"</summary>
		[JsonPropertyName("time")]
		public DateTime? Time { get; init; }

		///<summary>The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</summary>
		[JsonPropertyName("datetime")]
		public string? Datetime { get; init; }

		///<summary>The target date & time the entity should be set to as expressed by a UNIX timestamp.</summary>
		[JsonPropertyName("timestamp")]
		public long? Timestamp { get; init; }
	}

	public class InputNumberServices
	{
		private readonly IHaContext _haContext;
		public InputNumberServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Decrement the value of an input number entity by its stepping.</summary>
		///<param name="target">The target for this service call</param>
		public void Decrement(ServiceTarget target)
		{
			_haContext.CallService("input_number", "decrement", target);
		}

		///<summary>Increment the value of an input number entity by its stepping.</summary>
		///<param name="target">The target for this service call</param>
		public void Increment(ServiceTarget target)
		{
			_haContext.CallService("input_number", "increment", target);
		}

		///<summary>Reload the input_number configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_number", "reload", null);
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, InputNumberSetValueParameters data)
		{
			_haContext.CallService("input_number", "set_value", target, data);
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to.</param>
		public void SetValue(ServiceTarget target, double @value)
		{
			_haContext.CallService("input_number", "set_value", target, new InputNumberSetValueParameters{Value = @value});
		}
	}

	public record InputNumberSetValueParameters
	{
		///<summary>The target value the entity should be set to.</summary>
		[JsonPropertyName("value")]
		public double? Value { get; init; }
	}

	public class InputSelectServices
	{
		private readonly IHaContext _haContext;
		public InputSelectServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_select configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_select", "reload", null);
		}

		///<summary>Select the first option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectFirst(ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_first", target);
		}

		///<summary>Select the last option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectLast(ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_last", target);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectNext(ServiceTarget target, InputSelectSelectNextParameters data)
		{
			_haContext.CallService("input_select", "select_next", target, data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public void SelectNext(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_next", target, new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectOption(ServiceTarget target, InputSelectSelectOptionParameters data)
		{
			_haContext.CallService("input_select", "select_option", target, data);
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public void SelectOption(ServiceTarget target, string @option)
		{
			_haContext.CallService("input_select", "select_option", target, new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectPrevious(ServiceTarget target, InputSelectSelectPreviousParameters data)
		{
			_haContext.CallService("input_select", "select_previous", target, data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public void SelectPrevious(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_previous", target, new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetOptions(ServiceTarget target, InputSelectSetOptionsParameters data)
		{
			_haContext.CallService("input_select", "set_options", target, data);
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public void SetOptions(ServiceTarget target, object @options)
		{
			_haContext.CallService("input_select", "set_options", target, new InputSelectSetOptionsParameters{Options = @options});
		}
	}

	public record InputSelectSelectNextParameters
	{
		///<summary>If the option should cycle from the last to the first.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSelectOptionParameters
	{
		///<summary>Option to be selected. eg: "Item A"</summary>
		[JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public record InputSelectSelectPreviousParameters
	{
		///<summary>If the option should cycle from the first to the last.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSetOptionsParameters
	{
		///<summary>Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class InputTextServices
	{
		private readonly IHaContext _haContext;
		public InputTextServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_text configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_text", "reload", null);
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, InputTextSetValueParameters data)
		{
			_haContext.CallService("input_text", "set_value", target, data);
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to. eg: This is an example text</param>
		public void SetValue(ServiceTarget target, string @value)
		{
			_haContext.CallService("input_text", "set_value", target, new InputTextSetValueParameters{Value = @value});
		}
	}

	public record InputTextSetValueParameters
	{
		///<summary>The target value the entity should be set to. eg: This is an example text</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class LightServices
	{
		private readonly IHaContext _haContext;
		public LightServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target, LightToggleParameters data)
		{
			_haContext.CallService("light", "toggle", target, data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public void Toggle(ServiceTarget target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "toggle", target, new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target, LightTurnOffParameters data)
		{
			_haContext.CallService("light", "turn_off", target, data);
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public void TurnOff(ServiceTarget target, long? @transition = null, object? @flash = null)
		{
			_haContext.CallService("light", "turn_off", target, new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, LightTurnOnParameters data)
		{
			_haContext.CallService("light", "turn_on", target, data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public void TurnOn(ServiceTarget target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "turn_on", target, new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}
	}

	public record LightToggleParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>Color for the light in RGB-format. eg: [255, 100, 100]</summary>
		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		///<summary>A human readable color name.</summary>
		[JsonPropertyName("color_name")]
		public object? ColorName { get; init; }

		///<summary>Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</summary>
		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		///<summary>Color for the light in XY-format. eg: [0.52, 0.43]</summary>
		[JsonPropertyName("xy_color")]
		public object? XyColor { get; init; }

		///<summary>Color temperature for the light in mireds.</summary>
		[JsonPropertyName("color_temp")]
		public object? ColorTemp { get; init; }

		///<summary>Color temperature for the light in Kelvin.</summary>
		[JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		///<summary>Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		///<summary>Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness_pct")]
		public long? BrightnessPct { get; init; }

		///<summary>Name of a light profile to use. eg: relax</summary>
		[JsonPropertyName("profile")]
		public string? Profile { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }

		///<summary>Light effect.</summary>
		[JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public record LightTurnOffParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }
	}

	public record LightTurnOnParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>The color for the light (based on RGB - red, green, blue).</summary>
		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		///<summary>A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</summary>
		[JsonPropertyName("rgbw_color")]
		public object? RgbwColor { get; init; }

		///<summary>A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</summary>
		[JsonPropertyName("rgbww_color")]
		public object? RgbwwColor { get; init; }

		///<summary>A human readable color name.</summary>
		[JsonPropertyName("color_name")]
		public object? ColorName { get; init; }

		///<summary>Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</summary>
		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		///<summary>Color for the light in XY-format. eg: [0.52, 0.43]</summary>
		[JsonPropertyName("xy_color")]
		public object? XyColor { get; init; }

		///<summary>Color temperature for the light in mireds.</summary>
		[JsonPropertyName("color_temp")]
		public object? ColorTemp { get; init; }

		///<summary>Color temperature for the light in Kelvin.</summary>
		[JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		///<summary>Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		///<summary>Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness_pct")]
		public long? BrightnessPct { get; init; }

		///<summary>Change brightness by an amount.</summary>
		[JsonPropertyName("brightness_step")]
		public long? BrightnessStep { get; init; }

		///<summary>Change brightness by a percentage.</summary>
		[JsonPropertyName("brightness_step_pct")]
		public long? BrightnessStepPct { get; init; }

		///<summary>Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("white")]
		public long? White { get; init; }

		///<summary>Name of a light profile to use. eg: relax</summary>
		[JsonPropertyName("profile")]
		public string? Profile { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }

		///<summary>Light effect.</summary>
		[JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public class LockServices
	{
		private readonly IHaContext _haContext;
		public LockServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Lock(ServiceTarget target, LockLockParameters data)
		{
			_haContext.CallService("lock", "lock", target, data);
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to lock the lock with. eg: 1234</param>
		public void Lock(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "lock", target, new LockLockParameters{Code = @code});
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Open(ServiceTarget target, LockOpenParameters data)
		{
			_haContext.CallService("lock", "open", target, data);
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to open the lock with. eg: 1234</param>
		public void Open(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "open", target, new LockOpenParameters{Code = @code});
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Unlock(ServiceTarget target, LockUnlockParameters data)
		{
			_haContext.CallService("lock", "unlock", target, data);
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to unlock the lock with. eg: 1234</param>
		public void Unlock(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "unlock", target, new LockUnlockParameters{Code = @code});
		}
	}

	public record LockLockParameters
	{
		///<summary>An optional code to lock the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockOpenParameters
	{
		///<summary>An optional code to open the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockUnlockParameters
	{
		///<summary>An optional code to unlock the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class LogbookServices
	{
		private readonly IHaContext _haContext;
		public LogbookServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Create a custom entry in your logbook.</summary>
		public void Log(LogbookLogParameters data)
		{
			_haContext.CallService("logbook", "log", null, data);
		}

		///<summary>Create a custom entry in your logbook.</summary>
		///<param name="name">Custom name for an entity, can be referenced with entity_id. eg: Kitchen</param>
		///<param name="message">Message of the custom logbook entry. eg: is being used</param>
		///<param name="entityId">Entity to reference in custom logbook entry.</param>
		///<param name="domain">Icon of domain to display in custom logbook entry. eg: light</param>
		public void Log(string @name, string @message, string? @entityId = null, string? @domain = null)
		{
			_haContext.CallService("logbook", "log", null, new LogbookLogParameters{Name = @name, Message = @message, EntityId = @entityId, Domain = @domain});
		}
	}

	public record LogbookLogParameters
	{
		///<summary>Custom name for an entity, can be referenced with entity_id. eg: Kitchen</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Message of the custom logbook entry. eg: is being used</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Entity to reference in custom logbook entry.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Icon of domain to display in custom logbook entry. eg: light</summary>
		[JsonPropertyName("domain")]
		public string? Domain { get; init; }
	}

	public class LoggerServices
	{
		private readonly IHaContext _haContext;
		public LoggerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set the default log level for integrations.</summary>
		public void SetDefaultLevel(LoggerSetDefaultLevelParameters data)
		{
			_haContext.CallService("logger", "set_default_level", null, data);
		}

		///<summary>Set the default log level for integrations.</summary>
		///<param name="level">Default severity level for all integrations.</param>
		public void SetDefaultLevel(object? @level = null)
		{
			_haContext.CallService("logger", "set_default_level", null, new LoggerSetDefaultLevelParameters{Level = @level});
		}

		///<summary>Set log level for integrations.</summary>
		public void SetLevel()
		{
			_haContext.CallService("logger", "set_level", null);
		}
	}

	public record LoggerSetDefaultLevelParameters
	{
		///<summary>Default severity level for all integrations.</summary>
		[JsonPropertyName("level")]
		public object? Level { get; init; }
	}

	public class MediaPlayerServices
	{
		private readonly IHaContext _haContext;
		public MediaPlayerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send the media player the command to clear players playlist.</summary>
		///<param name="target">The target for this service call</param>
		public void ClearPlaylist(ServiceTarget target)
		{
			_haContext.CallService("media_player", "clear_playlist", target);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		public void Join(ServiceTarget target, MediaPlayerJoinParameters data)
		{
			_haContext.CallService("media_player", "join", target, data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: - media_player.multiroom_player2 - media_player.multiroom_player3 </param>
		public void Join(ServiceTarget target, string @groupMembers)
		{
			_haContext.CallService("media_player", "join", target, new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Send the media player the command for next track.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaNextTrack(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_next_track", target);
		}

		///<summary>Send the media player the command for pause.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPause(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_pause", target);
		}

		///<summary>Send the media player the command for play.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPlay(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play", target);
		}

		///<summary>Toggle media player play/pause state.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPlayPause(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play_pause", target);
		}

		///<summary>Send the media player the command for previous track.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPreviousTrack(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_previous_track", target);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaSeek(ServiceTarget target, MediaPlayerMediaSeekParameters data)
		{
			_haContext.CallService("media_player", "media_seek", target, data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public void MediaSeek(ServiceTarget target, double @seekPosition)
		{
			_haContext.CallService("media_player", "media_seek", target, new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the stop command.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaStop(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_stop", target);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The target for this service call</param>
		public void PlayMedia(ServiceTarget target, MediaPlayerPlayMediaParameters data)
		{
			_haContext.CallService("media_player", "play_media", target, data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public void PlayMedia(ServiceTarget target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			_haContext.CallService("media_player", "play_media", target, new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The target for this service call</param>
		public void RepeatSet(ServiceTarget target, MediaPlayerRepeatSetParameters data)
		{
			_haContext.CallService("media_player", "repeat_set", target, data);
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The target for this service call</param>
		///<param name="repeat">Repeat mode to set.</param>
		public void RepeatSet(ServiceTarget target, object @repeat)
		{
			_haContext.CallService("media_player", "repeat_set", target, new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectSoundMode(ServiceTarget target, MediaPlayerSelectSoundModeParameters data)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public void SelectSoundMode(ServiceTarget target, string? @soundMode = null)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectSource(ServiceTarget target, MediaPlayerSelectSourceParameters data)
		{
			_haContext.CallService("media_player", "select_source", target, data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public void SelectSource(ServiceTarget target, string @source)
		{
			_haContext.CallService("media_player", "select_source", target, new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The target for this service call</param>
		public void ShuffleSet(ServiceTarget target, MediaPlayerShuffleSetParameters data)
		{
			_haContext.CallService("media_player", "shuffle_set", target, data);
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public void ShuffleSet(ServiceTarget target, bool @shuffle)
		{
			_haContext.CallService("media_player", "shuffle_set", target, new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Toggles a media player power state.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("media_player", "toggle", target);
		}

		///<summary>Turn a media player power off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_off", target);
		}

		///<summary>Turn a media player power on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_on", target);
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		public void Unjoin(ServiceTarget target)
		{
			_haContext.CallService("media_player", "unjoin", target);
		}

		///<summary>Turn a media player volume down.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeDown(ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_down", target);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeMute(ServiceTarget target, MediaPlayerVolumeMuteParameters data)
		{
			_haContext.CallService("media_player", "volume_mute", target, data);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public void VolumeMute(ServiceTarget target, bool @isVolumeMuted)
		{
			_haContext.CallService("media_player", "volume_mute", target, new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeSet(ServiceTarget target, MediaPlayerVolumeSetParameters data)
		{
			_haContext.CallService("media_player", "volume_set", target, data);
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public void VolumeSet(ServiceTarget target, double @volumeLevel)
		{
			_haContext.CallService("media_player", "volume_set", target, new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Turn a media player volume up.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeUp(ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_up", target);
		}
	}

	public record MediaPlayerJoinParameters
	{
		///<summary>The players which will be synced with the target player. eg: - media_player.multiroom_player2 - media_player.multiroom_player3 </summary>
		[JsonPropertyName("group_members")]
		public string? GroupMembers { get; init; }
	}

	public record MediaPlayerMediaSeekParameters
	{
		///<summary>Position to seek to. The format is platform dependent.</summary>
		[JsonPropertyName("seek_position")]
		public double? SeekPosition { get; init; }
	}

	public record MediaPlayerPlayMediaParameters
	{
		///<summary>The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</summary>
		[JsonPropertyName("media_content_id")]
		public string? MediaContentId { get; init; }

		///<summary>The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</summary>
		[JsonPropertyName("media_content_type")]
		public string? MediaContentType { get; init; }

		///<summary>If the content should be played now or be added to the queue.</summary>
		[JsonPropertyName("enqueue")]
		public object? Enqueue { get; init; }

		///<summary>If the media should be played as an announcement. eg: true</summary>
		[JsonPropertyName("announce")]
		public bool? Announce { get; init; }
	}

	public record MediaPlayerRepeatSetParameters
	{
		///<summary>Repeat mode to set.</summary>
		[JsonPropertyName("repeat")]
		public object? Repeat { get; init; }
	}

	public record MediaPlayerSelectSoundModeParameters
	{
		///<summary>Name of the sound mode to switch to. eg: Music</summary>
		[JsonPropertyName("sound_mode")]
		public string? SoundMode { get; init; }
	}

	public record MediaPlayerSelectSourceParameters
	{
		///<summary>Name of the source to switch to. Platform dependent. eg: video1</summary>
		[JsonPropertyName("source")]
		public string? Source { get; init; }
	}

	public record MediaPlayerShuffleSetParameters
	{
		///<summary>True/false for enabling/disabling shuffle.</summary>
		[JsonPropertyName("shuffle")]
		public bool? Shuffle { get; init; }
	}

	public record MediaPlayerVolumeMuteParameters
	{
		///<summary>True/false for mute/unmute.</summary>
		[JsonPropertyName("is_volume_muted")]
		public bool? IsVolumeMuted { get; init; }
	}

	public record MediaPlayerVolumeSetParameters
	{
		///<summary>Volume level to set as float.</summary>
		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }
	}

	public class MqttServices
	{
		private readonly IHaContext _haContext;
		public MqttServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Dump messages on a topic selector to the 'mqtt_dump.txt' file in your configuration folder.</summary>
		public void Dump(MqttDumpParameters data)
		{
			_haContext.CallService("mqtt", "dump", null, data);
		}

		///<summary>Dump messages on a topic selector to the 'mqtt_dump.txt' file in your configuration folder.</summary>
		///<param name="topic">topic to listen to eg: OpenZWave/#</param>
		///<param name="duration">how long we should listen for messages in seconds</param>
		public void Dump(string? @topic = null, long? @duration = null)
		{
			_haContext.CallService("mqtt", "dump", null, new MqttDumpParameters{Topic = @topic, Duration = @duration});
		}

		///<summary>Publish a message to an MQTT topic.</summary>
		public void Publish(MqttPublishParameters data)
		{
			_haContext.CallService("mqtt", "publish", null, data);
		}

		///<summary>Publish a message to an MQTT topic.</summary>
		///<param name="topic">Topic to publish payload. eg: /homeassistant/hello</param>
		///<param name="payload">Payload to publish. eg: This is great</param>
		///<param name="payloadTemplate">Template to render as payload value. Ignored if payload given. eg: {{ states('sensor.temperature') }}</param>
		///<param name="qos">Quality of Service to use.</param>
		///<param name="retain">If message should have the retain flag set.</param>
		public void Publish(string @topic, string? @payload = null, object? @payloadTemplate = null, object? @qos = null, bool? @retain = null)
		{
			_haContext.CallService("mqtt", "publish", null, new MqttPublishParameters{Topic = @topic, Payload = @payload, PayloadTemplate = @payloadTemplate, Qos = @qos, Retain = @retain});
		}

		///<summary>Reload all MQTT entities from YAML.</summary>
		public void Reload()
		{
			_haContext.CallService("mqtt", "reload", null);
		}
	}

	public record MqttDumpParameters
	{
		///<summary>topic to listen to eg: OpenZWave/#</summary>
		[JsonPropertyName("topic")]
		public string? Topic { get; init; }

		///<summary>how long we should listen for messages in seconds</summary>
		[JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record MqttPublishParameters
	{
		///<summary>Topic to publish payload. eg: /homeassistant/hello</summary>
		[JsonPropertyName("topic")]
		public string? Topic { get; init; }

		///<summary>Payload to publish. eg: This is great</summary>
		[JsonPropertyName("payload")]
		public string? Payload { get; init; }

		///<summary>Template to render as payload value. Ignored if payload given. eg: {{ states('sensor.temperature') }}</summary>
		[JsonPropertyName("payload_template")]
		public object? PayloadTemplate { get; init; }

		///<summary>Quality of Service to use.</summary>
		[JsonPropertyName("qos")]
		public object? Qos { get; init; }

		///<summary>If message should have the retain flag set.</summary>
		[JsonPropertyName("retain")]
		public bool? Retain { get; init; }
	}

	public class NotifyServices
	{
		private readonly IHaContext _haContext;
		public NotifyServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Sends a notification message using the envy service.</summary>
		public void Envy(NotifyEnvyParameters data)
		{
			_haContext.CallService("notify", "envy", null, data);
		}

		///<summary>Sends a notification message using the envy service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void Envy(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "envy", null, new NotifyEnvyParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the mobile_app_moto_g_8_power_lite integration.</summary>
		public void MobileAppMotoG8PowerLite(NotifyMobileAppMotoG8PowerLiteParameters data)
		{
			_haContext.CallService("notify", "mobile_app_moto_g_8_power_lite", null, data);
		}

		///<summary>Sends a notification message using the mobile_app_moto_g_8_power_lite integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void MobileAppMotoG8PowerLite(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_moto_g_8_power_lite", null, new NotifyMobileAppMotoG8PowerLiteParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the mobile_app_sm_t530 integration.</summary>
		public void MobileAppSmT530(NotifyMobileAppSmT530Parameters data)
		{
			_haContext.CallService("notify", "mobile_app_sm_t530", null, data);
		}

		///<summary>Sends a notification message using the mobile_app_sm_t530 integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void MobileAppSmT530(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_sm_t530", null, new NotifyMobileAppSmT530Parameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the notify service.</summary>
		public void Notify(NotifyNotifyParameters data)
		{
			_haContext.CallService("notify", "notify", null, data);
		}

		///<summary>Sends a notification message using the notify service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void Notify(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "notify", null, new NotifyNotifyParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the pc service.</summary>
		public void Pc(NotifyPcParameters data)
		{
			_haContext.CallService("notify", "pc", null, data);
		}

		///<summary>Sends a notification message using the pc service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void Pc(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "pc", null, new NotifyPcParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification that is visible in the front-end.</summary>
		public void PersistentNotification(NotifyPersistentNotificationParameters data)
		{
			_haContext.CallService("notify", "persistent_notification", null, data);
		}

		///<summary>Sends a notification that is visible in the front-end.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		public void PersistentNotification(string @message, string? @title = null)
		{
			_haContext.CallService("notify", "persistent_notification", null, new NotifyPersistentNotificationParameters{Message = @message, Title = @title});
		}
	}

	public record NotifyEnvyParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppMotoG8PowerLiteParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppSmT530Parameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyNotifyParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyPcParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyPersistentNotificationParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public class NumberServices
	{
		private readonly IHaContext _haContext;
		public NumberServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, NumberSetValueParameters data)
		{
			_haContext.CallService("number", "set_value", target, data);
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public void SetValue(ServiceTarget target, string? @value = null)
		{
			_haContext.CallService("number", "set_value", target, new NumberSetValueParameters{Value = @value});
		}
	}

	public record NumberSetValueParameters
	{
		///<summary>The target value the entity should be set to. eg: 42</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class PersistentNotificationServices
	{
		private readonly IHaContext _haContext;
		public PersistentNotificationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Show a notification in the frontend.</summary>
		public void Create(PersistentNotificationCreateParameters data)
		{
			_haContext.CallService("persistent_notification", "create", null, data);
		}

		///<summary>Show a notification in the frontend.</summary>
		///<param name="message">Message body of the notification. [Templates accepted] eg: Please check your configuration.yaml.</param>
		///<param name="title">Optional title for your notification. [Templates accepted] eg: Test notification</param>
		///<param name="notificationId">Target ID of the notification, will replace a notification with the same ID. eg: 1234</param>
		public void Create(string @message, string? @title = null, string? @notificationId = null)
		{
			_haContext.CallService("persistent_notification", "create", null, new PersistentNotificationCreateParameters{Message = @message, Title = @title, NotificationId = @notificationId});
		}

		///<summary>Remove a notification from the frontend.</summary>
		public void Dismiss(PersistentNotificationDismissParameters data)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, data);
		}

		///<summary>Remove a notification from the frontend.</summary>
		///<param name="notificationId">Target ID of the notification, which should be removed. eg: 1234</param>
		public void Dismiss(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, new PersistentNotificationDismissParameters{NotificationId = @notificationId});
		}

		///<summary>Mark a notification read.</summary>
		public void MarkRead(PersistentNotificationMarkReadParameters data)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, data);
		}

		///<summary>Mark a notification read.</summary>
		///<param name="notificationId">Target ID of the notification, which should be mark read. eg: 1234</param>
		public void MarkRead(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, new PersistentNotificationMarkReadParameters{NotificationId = @notificationId});
		}
	}

	public record PersistentNotificationCreateParameters
	{
		///<summary>Message body of the notification. [Templates accepted] eg: Please check your configuration.yaml.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Optional title for your notification. [Templates accepted] eg: Test notification</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>Target ID of the notification, will replace a notification with the same ID. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationDismissParameters
	{
		///<summary>Target ID of the notification, which should be removed. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationMarkReadParameters
	{
		///<summary>Target ID of the notification, which should be mark read. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public class PersonServices
	{
		private readonly IHaContext _haContext;
		public PersonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the person configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("person", "reload", null);
		}
	}

	public class RecorderServices
	{
		private readonly IHaContext _haContext;
		public RecorderServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Stop the recording of events and state changes</summary>
		public void Disable()
		{
			_haContext.CallService("recorder", "disable", null);
		}

		///<summary>Start the recording of events and state changes</summary>
		public void Enable()
		{
			_haContext.CallService("recorder", "enable", null);
		}

		///<summary>Start purge task - to clean up old data from your database.</summary>
		public void Purge(RecorderPurgeParameters data)
		{
			_haContext.CallService("recorder", "purge", null, data);
		}

		///<summary>Start purge task - to clean up old data from your database.</summary>
		///<param name="keepDays">Number of history days to keep in database after purge.</param>
		///<param name="repack">Attempt to save disk space by rewriting the entire database file.</param>
		///<param name="applyFilter">Apply entity_id and event_type filter in addition to time based purge.</param>
		public void Purge(long? @keepDays = null, bool? @repack = null, bool? @applyFilter = null)
		{
			_haContext.CallService("recorder", "purge", null, new RecorderPurgeParameters{KeepDays = @keepDays, Repack = @repack, ApplyFilter = @applyFilter});
		}

		///<summary>Start purge task to remove specific entities from your database.</summary>
		///<param name="target">The target for this service call</param>
		public void PurgeEntities(ServiceTarget target, RecorderPurgeEntitiesParameters data)
		{
			_haContext.CallService("recorder", "purge_entities", target, data);
		}

		///<summary>Start purge task to remove specific entities from your database.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="domains">List the domains that need to be removed from the recorder database. eg: sun</param>
		///<param name="entityGlobs">List the glob patterns to select entities for removal from the recorder database. eg: domain*.object_id*</param>
		public void PurgeEntities(ServiceTarget target, object? @domains = null, object? @entityGlobs = null)
		{
			_haContext.CallService("recorder", "purge_entities", target, new RecorderPurgeEntitiesParameters{Domains = @domains, EntityGlobs = @entityGlobs});
		}
	}

	public record RecorderPurgeParameters
	{
		///<summary>Number of history days to keep in database after purge.</summary>
		[JsonPropertyName("keep_days")]
		public long? KeepDays { get; init; }

		///<summary>Attempt to save disk space by rewriting the entire database file.</summary>
		[JsonPropertyName("repack")]
		public bool? Repack { get; init; }

		///<summary>Apply entity_id and event_type filter in addition to time based purge.</summary>
		[JsonPropertyName("apply_filter")]
		public bool? ApplyFilter { get; init; }
	}

	public record RecorderPurgeEntitiesParameters
	{
		///<summary>List the domains that need to be removed from the recorder database. eg: sun</summary>
		[JsonPropertyName("domains")]
		public object? Domains { get; init; }

		///<summary>List the glob patterns to select entities for removal from the recorder database. eg: domain*.object_id*</summary>
		[JsonPropertyName("entity_globs")]
		public object? EntityGlobs { get; init; }
	}

	public class SceneServices
	{
		private readonly IHaContext _haContext;
		public SceneServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Activate a scene with configuration.</summary>
		public void Apply(SceneApplyParameters data)
		{
			_haContext.CallService("scene", "apply", null, data);
		}

		///<summary>Activate a scene with configuration.</summary>
		///<param name="entities">The entities and the state that they need to be. eg: {"light.kitchen":"on","light.ceiling":{"state":"on","brightness":80}}</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public void Apply(object @entities, long? @transition = null)
		{
			_haContext.CallService("scene", "apply", null, new SceneApplyParameters{Entities = @entities, Transition = @transition});
		}

		///<summary>Creates a new scene.</summary>
		public void Create(SceneCreateParameters data)
		{
			_haContext.CallService("scene", "create", null, data);
		}

		///<summary>Creates a new scene.</summary>
		///<param name="sceneId">The entity_id of the new scene. eg: all_lights</param>
		///<param name="entities">The entities to control with the scene. eg: {"light.tv_back_light":"on","light.ceiling":{"state":"on","brightness":200}}</param>
		///<param name="snapshotEntities">The entities of which a snapshot is to be taken eg: ["light.ceiling","light.kitchen"]</param>
		public void Create(string @sceneId, object? @entities = null, object? @snapshotEntities = null)
		{
			_haContext.CallService("scene", "create", null, new SceneCreateParameters{SceneId = @sceneId, Entities = @entities, SnapshotEntities = @snapshotEntities});
		}

		///<summary>Reload the scene configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("scene", "reload", null);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, SceneTurnOnParameters data)
		{
			_haContext.CallService("scene", "turn_on", target, data);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public void TurnOn(ServiceTarget target, long? @transition = null)
		{
			_haContext.CallService("scene", "turn_on", target, new SceneTurnOnParameters{Transition = @transition});
		}
	}

	public record SceneApplyParameters
	{
		///<summary>The entities and the state that they need to be. eg: {"light.kitchen":"on","light.ceiling":{"state":"on","brightness":80}}</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>Transition duration it takes to bring devices to the state defined in the scene.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public record SceneCreateParameters
	{
		///<summary>The entity_id of the new scene. eg: all_lights</summary>
		[JsonPropertyName("scene_id")]
		public string? SceneId { get; init; }

		///<summary>The entities to control with the scene. eg: {"light.tv_back_light":"on","light.ceiling":{"state":"on","brightness":200}}</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>The entities of which a snapshot is to be taken eg: ["light.ceiling","light.kitchen"]</summary>
		[JsonPropertyName("snapshot_entities")]
		public object? SnapshotEntities { get; init; }
	}

	public record SceneTurnOnParameters
	{
		///<summary>Transition duration it takes to bring devices to the state defined in the scene.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public class ScheduleServices
	{
		private readonly IHaContext _haContext;
		public ScheduleServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the schedule configuration</summary>
		public void Reload()
		{
			_haContext.CallService("schedule", "reload", null);
		}
	}

	public class SchedulerServices
	{
		private readonly IHaContext _haContext;
		public SchedulerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Create a new schedule entity</summary>
		public void Add(SchedulerAddParameters data)
		{
			_haContext.CallService("scheduler", "add", null, data);
		}

		///<summary>Create a new schedule entity</summary>
		///<param name="weekdays">Days of the week for which the schedule should be repeated eg: ["daily"]</param>
		///<param name="startDate">Date from which schedule should be executed eg: ["2021-01-01"]</param>
		///<param name="endDate">Date until which schedule should be executed eg: ["2021-12-31"]</param>
		///<param name="timeslots">list of timeslots with their actions and optionally conditions (should be kept the same for all timeslots) eg: [{start: "12:00", stop: "13:00", actions: [{service: "light.turn_on", entity_id: "light.my_lamp", service_data: {brightness: 200}}]}]</param>
		///<param name="repeatType">Control what happens after the schedule is triggered eg: "repeat"</param>
		///<param name="name">Friendly name for the schedule eg: My schedule</param>
		public void Add(object @timeslots, object @repeatType, object? @weekdays = null, object? @startDate = null, object? @endDate = null, string? @name = null)
		{
			_haContext.CallService("scheduler", "add", null, new SchedulerAddParameters{Weekdays = @weekdays, StartDate = @startDate, EndDate = @endDate, Timeslots = @timeslots, RepeatType = @repeatType, Name = @name});
		}

		///<summary>Duplicate a schedule entity</summary>
		public void Copy(SchedulerCopyParameters data)
		{
			_haContext.CallService("scheduler", "copy", null, data);
		}

		///<summary>Duplicate a schedule entity</summary>
		///<param name="entityId">Identifier of the scheduler entity. eg: switch.schedule_abcdef</param>
		///<param name="name">Friendly name for the copied schedule eg: My schedule</param>
		public void Copy(string @entityId, string? @name = null)
		{
			_haContext.CallService("scheduler", "copy", null, new SchedulerCopyParameters{EntityId = @entityId, Name = @name});
		}

		///<summary>Edit a schedule entity</summary>
		public void Edit(SchedulerEditParameters data)
		{
			_haContext.CallService("scheduler", "edit", null, data);
		}

		///<summary>Edit a schedule entity</summary>
		///<param name="entityId">Identifier of the scheduler entity. eg: switch.schedule_abcdef</param>
		///<param name="weekdays">Days of the week for which the schedule should be repeated eg: ["daily"]</param>
		///<param name="startDate">Date from which schedule should be executed eg: ["2021-01-01"]</param>
		///<param name="endDate">Date until which schedule should be executed eg: ["2021-12-31"]</param>
		///<param name="timeslots">list of timeslots with their actions and optionally conditions (should be kept the same for all timeslots) eg: [{start: "12:00", stop: "13:00", actions: [{service: "light.turn_on", entity_id: "light.my_lamp", service_data: {brightness: 200}}]}]</param>
		///<param name="repeatType">Control what happens after the schedule is triggered eg: "repeat"</param>
		///<param name="name">Friendly name for the schedule eg: My schedule</param>
		public void Edit(string @entityId, object? @weekdays = null, object? @startDate = null, object? @endDate = null, object? @timeslots = null, object? @repeatType = null, string? @name = null)
		{
			_haContext.CallService("scheduler", "edit", null, new SchedulerEditParameters{EntityId = @entityId, Weekdays = @weekdays, StartDate = @startDate, EndDate = @endDate, Timeslots = @timeslots, RepeatType = @repeatType, Name = @name});
		}

		///<summary>Remove a schedule entity</summary>
		public void Remove(SchedulerRemoveParameters data)
		{
			_haContext.CallService("scheduler", "remove", null, data);
		}

		///<summary>Remove a schedule entity</summary>
		///<param name="entityId">Identifier of the scheduler entity. eg: switch.schedule_abcdef</param>
		public void Remove(string @entityId)
		{
			_haContext.CallService("scheduler", "remove", null, new SchedulerRemoveParameters{EntityId = @entityId});
		}

		///<summary>Execute the action of a schedule, optionally at a given time.</summary>
		public void RunAction(SchedulerRunActionParameters data)
		{
			_haContext.CallService("scheduler", "run_action", null, data);
		}

		///<summary>Execute the action of a schedule, optionally at a given time.</summary>
		///<param name="entityId">Identifier of the scheduler entity. eg: switch.schedule_abcdef</param>
		///<param name="time">Time for which to evaluate the action (only useful for schedules with multiple timeslot) eg: "12:00"</param>
		public void RunAction(string @entityId, DateTime? @time = null)
		{
			_haContext.CallService("scheduler", "run_action", null, new SchedulerRunActionParameters{EntityId = @entityId, Time = @time});
		}
	}

	public record SchedulerAddParameters
	{
		///<summary>Days of the week for which the schedule should be repeated eg: ["daily"]</summary>
		[JsonPropertyName("weekdays")]
		public object? Weekdays { get; init; }

		///<summary>Date from which schedule should be executed eg: ["2021-01-01"]</summary>
		[JsonPropertyName("start_date")]
		public object? StartDate { get; init; }

		///<summary>Date until which schedule should be executed eg: ["2021-12-31"]</summary>
		[JsonPropertyName("end_date")]
		public object? EndDate { get; init; }

		///<summary>list of timeslots with their actions and optionally conditions (should be kept the same for all timeslots) eg: [{start: "12:00", stop: "13:00", actions: [{service: "light.turn_on", entity_id: "light.my_lamp", service_data: {brightness: 200}}]}]</summary>
		[JsonPropertyName("timeslots")]
		public object? Timeslots { get; init; }

		///<summary>Control what happens after the schedule is triggered eg: "repeat"</summary>
		[JsonPropertyName("repeat_type")]
		public object? RepeatType { get; init; }

		///<summary>Friendly name for the schedule eg: My schedule</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record SchedulerCopyParameters
	{
		///<summary>Identifier of the scheduler entity. eg: switch.schedule_abcdef</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Friendly name for the copied schedule eg: My schedule</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record SchedulerEditParameters
	{
		///<summary>Identifier of the scheduler entity. eg: switch.schedule_abcdef</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Days of the week for which the schedule should be repeated eg: ["daily"]</summary>
		[JsonPropertyName("weekdays")]
		public object? Weekdays { get; init; }

		///<summary>Date from which schedule should be executed eg: ["2021-01-01"]</summary>
		[JsonPropertyName("start_date")]
		public object? StartDate { get; init; }

		///<summary>Date until which schedule should be executed eg: ["2021-12-31"]</summary>
		[JsonPropertyName("end_date")]
		public object? EndDate { get; init; }

		///<summary>list of timeslots with their actions and optionally conditions (should be kept the same for all timeslots) eg: [{start: "12:00", stop: "13:00", actions: [{service: "light.turn_on", entity_id: "light.my_lamp", service_data: {brightness: 200}}]}]</summary>
		[JsonPropertyName("timeslots")]
		public object? Timeslots { get; init; }

		///<summary>Control what happens after the schedule is triggered eg: "repeat"</summary>
		[JsonPropertyName("repeat_type")]
		public object? RepeatType { get; init; }

		///<summary>Friendly name for the schedule eg: My schedule</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record SchedulerRemoveParameters
	{
		///<summary>Identifier of the scheduler entity. eg: switch.schedule_abcdef</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public record SchedulerRunActionParameters
	{
		///<summary>Identifier of the scheduler entity. eg: switch.schedule_abcdef</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Time for which to evaluate the action (only useful for schedules with multiple timeslot) eg: "12:00"</summary>
		[JsonPropertyName("time")]
		public DateTime? Time { get; init; }
	}

	public class ScriptServices
	{
		private readonly IHaContext _haContext;
		public ScriptServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void HA1659477669028()
		{
			_haContext.CallService("script", "1659477669028", null);
		}

		public void AvVolumeDown()
		{
			_haContext.CallService("script", "av_volume_down", null);
		}

		public void AvVolumeUp()
		{
			_haContext.CallService("script", "av_volume_up", null);
		}

		public void PccancelShutDown()
		{
			_haContext.CallService("script", "pccancel_shut_down", null);
		}

		public void PcturnOffPc()
		{
			_haContext.CallService("script", "pcturn_off_pc", null);
		}

		public void ReadOutElectricityPrice()
		{
			_haContext.CallService("script", "read_out_electricity_price", null);
		}

		public void ReadoutLasttimeAwoken()
		{
			_haContext.CallService("script", "readout_lasttime_awoken", null);
		}

		///<summary>Reload all the available scripts</summary>
		public void Reload()
		{
			_haContext.CallService("script", "reload", null);
		}

		///<summary>Send a audio notification</summary>
		public void SendAudioNotification(ScriptSendAudioNotificationParameters data)
		{
			_haContext.CallService("script", "send_audio_notification", null, data);
		}

		///<summary>Send a audio notification</summary>
		///<param name="title">The title of the notification eg: State change</param>
		///<param name="message">The message content eg: The light is on!</param>
		public void SendAudioNotification(object? @title = null, object? @message = null)
		{
			_haContext.CallService("script", "send_audio_notification", null, new ScriptSendAudioNotificationParameters{Title = @title, Message = @message});
		}

		///<summary>Send a audio notification</summary>
		public void SendAudioNotificationFile(ScriptSendAudioNotificationFileParameters data)
		{
			_haContext.CallService("script", "send_audio_notification_file", null, data);
		}

		///<summary>Send a audio notification</summary>
		///<param name="title">The title of the notification eg: State change</param>
		///<param name="message">The message content eg: The light is on!</param>
		public void SendAudioNotificationFile(object? @title = null, object? @message = null)
		{
			_haContext.CallService("script", "send_audio_notification_file", null, new ScriptSendAudioNotificationFileParameters{Title = @title, Message = @message});
		}

		///<summary>Toggle script</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("script", "toggle", target);
		}

		///<summary>Turn off script</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("script", "turn_off", target);
		}

		public void TurnOffServer()
		{
			_haContext.CallService("script", "turn_off_server", null);
		}

		///<summary>Turn on script</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("script", "turn_on", target);
		}

		public void TurnOnServer()
		{
			_haContext.CallService("script", "turn_on_server", null);
		}
	}

	public record ScriptSendAudioNotificationParameters
	{
		///<summary>The title of the notification eg: State change</summary>
		[JsonPropertyName("title")]
		public object? Title { get; init; }

		///<summary>The message content eg: The light is on!</summary>
		[JsonPropertyName("message")]
		public object? Message { get; init; }
	}

	public record ScriptSendAudioNotificationFileParameters
	{
		///<summary>The title of the notification eg: State change</summary>
		[JsonPropertyName("title")]
		public object? Title { get; init; }

		///<summary>The message content eg: The light is on!</summary>
		[JsonPropertyName("message")]
		public object? Message { get; init; }
	}

	public class SelectServices
	{
		private readonly IHaContext _haContext;
		public SelectServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Select the first option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectFirst(ServiceTarget target)
		{
			_haContext.CallService("select", "select_first", target);
		}

		///<summary>Select the last option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectLast(ServiceTarget target)
		{
			_haContext.CallService("select", "select_last", target);
		}

		///<summary>Select the next options of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectNext(ServiceTarget target, SelectSelectNextParameters data)
		{
			_haContext.CallService("select", "select_next", target, data);
		}

		///<summary>Select the next options of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public void SelectNext(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("select", "select_next", target, new SelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectOption(ServiceTarget target, SelectSelectOptionParameters data)
		{
			_haContext.CallService("select", "select_option", target, data);
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public void SelectOption(ServiceTarget target, string @option)
		{
			_haContext.CallService("select", "select_option", target, new SelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectPrevious(ServiceTarget target, SelectSelectPreviousParameters data)
		{
			_haContext.CallService("select", "select_previous", target, data);
		}

		///<summary>Select the previous options of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public void SelectPrevious(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("select", "select_previous", target, new SelectSelectPreviousParameters{Cycle = @cycle});
		}
	}

	public record SelectSelectNextParameters
	{
		///<summary>If the option should cycle from the last to the first.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record SelectSelectOptionParameters
	{
		///<summary>Option to be selected. eg: "Item A"</summary>
		[JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public record SelectSelectPreviousParameters
	{
		///<summary>If the option should cycle from the first to the last.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public class ShellCommandServices
	{
		private readonly IHaContext _haContext;
		public ShellCommandServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void TurnOffQnap()
		{
			_haContext.CallService("shell_command", "turn_off_qnap", null);
		}
	}

	public class SirenServices
	{
		private readonly IHaContext _haContext;
		public SirenServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles a siren.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("siren", "toggle", target);
		}

		///<summary>Turn siren off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("siren", "turn_off", target);
		}

		///<summary>Turn siren on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, SirenTurnOnParameters data)
		{
			_haContext.CallService("siren", "turn_on", target, data);
		}

		///<summary>Turn siren on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="tone">The tone to emit when turning the siren on. When `available_tones` property is a map, either the key or the value can be used. Must be supported by the integration. eg: fire</param>
		///<param name="volumeLevel">The volume level of the noise to emit when turning the siren on. Must be supported by the integration. eg: 0.5</param>
		///<param name="duration">The duration in seconds of the noise to emit when turning the siren on. Must be supported by the integration. eg: 15</param>
		public void TurnOn(ServiceTarget target, string? @tone = null, double? @volumeLevel = null, string? @duration = null)
		{
			_haContext.CallService("siren", "turn_on", target, new SirenTurnOnParameters{Tone = @tone, VolumeLevel = @volumeLevel, Duration = @duration});
		}
	}

	public record SirenTurnOnParameters
	{
		///<summary>The tone to emit when turning the siren on. When `available_tones` property is a map, either the key or the value can be used. Must be supported by the integration. eg: fire</summary>
		[JsonPropertyName("tone")]
		public string? Tone { get; init; }

		///<summary>The volume level of the noise to emit when turning the siren on. Must be supported by the integration. eg: 0.5</summary>
		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }

		///<summary>The duration in seconds of the noise to emit when turning the siren on. Must be supported by the integration. eg: 15</summary>
		[JsonPropertyName("duration")]
		public string? Duration { get; init; }
	}

	public class SwitchServices
	{
		private readonly IHaContext _haContext;
		public SwitchServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles a switch state</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("switch", "toggle", target);
		}

		///<summary>Turn a switch off</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_off", target);
		}

		///<summary>Turn a switch on</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_on", target);
		}
	}

	public class SystemLogServices
	{
		private readonly IHaContext _haContext;
		public SystemLogServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Clear all log entries.</summary>
		public void Clear()
		{
			_haContext.CallService("system_log", "clear", null);
		}

		///<summary>Write log entry.</summary>
		public void Write(SystemLogWriteParameters data)
		{
			_haContext.CallService("system_log", "write", null, data);
		}

		///<summary>Write log entry.</summary>
		///<param name="message">Message to log. eg: Something went wrong</param>
		///<param name="level">Log level.</param>
		///<param name="logger">Logger name under which to log the message. Defaults to 'system_log.external'. eg: mycomponent.myplatform</param>
		public void Write(string @message, object? @level = null, string? @logger = null)
		{
			_haContext.CallService("system_log", "write", null, new SystemLogWriteParameters{Message = @message, Level = @level, Logger = @logger});
		}
	}

	public record SystemLogWriteParameters
	{
		///<summary>Message to log. eg: Something went wrong</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Log level.</summary>
		[JsonPropertyName("level")]
		public object? Level { get; init; }

		///<summary>Logger name under which to log the message. Defaults to 'system_log.external'. eg: mycomponent.myplatform</summary>
		[JsonPropertyName("logger")]
		public string? Logger { get; init; }
	}

	public class TemplateServices
	{
		private readonly IHaContext _haContext;
		public TemplateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload all template entities.</summary>
		public void Reload()
		{
			_haContext.CallService("template", "reload", null);
		}
	}

	public class TextServices
	{
		private readonly IHaContext _haContext;
		public TextServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set value of a text entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, TextSetValueParameters data)
		{
			_haContext.CallService("text", "set_value", target, data);
		}

		///<summary>Set value of a text entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">Value to set. eg: Hello world!</param>
		public void SetValue(ServiceTarget target, string @value)
		{
			_haContext.CallService("text", "set_value", target, new TextSetValueParameters{Value = @value});
		}
	}

	public record TextSetValueParameters
	{
		///<summary>Value to set. eg: Hello world!</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class TimerServices
	{
		private readonly IHaContext _haContext;
		public TimerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Cancel a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Cancel(ServiceTarget target)
		{
			_haContext.CallService("timer", "cancel", target);
		}

		///<summary>Finish a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Finish(ServiceTarget target)
		{
			_haContext.CallService("timer", "finish", target);
		}

		///<summary>Pause a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Pause(ServiceTarget target)
		{
			_haContext.CallService("timer", "pause", target);
		}

		public void Reload()
		{
			_haContext.CallService("timer", "reload", null);
		}

		///<summary>Start a timer</summary>
		///<param name="target">The target for this service call</param>
		public void Start(ServiceTarget target, TimerStartParameters data)
		{
			_haContext.CallService("timer", "start", target, data);
		}

		///<summary>Start a timer</summary>
		///<param name="target">The target for this service call</param>
		///<param name="duration">Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</param>
		public void Start(ServiceTarget target, string? @duration = null)
		{
			_haContext.CallService("timer", "start", target, new TimerStartParameters{Duration = @duration});
		}
	}

	public record TimerStartParameters
	{
		///<summary>Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</summary>
		[JsonPropertyName("duration")]
		public string? Duration { get; init; }
	}

	public class TtsServices
	{
		private readonly IHaContext _haContext;
		public TtsServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Remove all text-to-speech cache files and RAM cache.</summary>
		public void ClearCache()
		{
			_haContext.CallService("tts", "clear_cache", null);
		}

		///<summary>Say something using text-to-speech on a media player with google_translate.</summary>
		public void GoogleTranslateSay(TtsGoogleTranslateSayParameters data)
		{
			_haContext.CallService("tts", "google_translate_say", null, data);
		}

		///<summary>Say something using text-to-speech on a media player with google_translate.</summary>
		///<param name="entityId">Name(s) of media player entities.</param>
		///<param name="message">Text to speak on devices. eg: My name is hanna</param>
		///<param name="cache">Control file cache of this message.</param>
		///<param name="language">Language to use for speech generation. eg: ru</param>
		///<param name="options">A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</param>
		public void GoogleTranslateSay(string @entityId, string @message, bool? @cache = null, string? @language = null, object? @options = null)
		{
			_haContext.CallService("tts", "google_translate_say", null, new TtsGoogleTranslateSayParameters{EntityId = @entityId, Message = @message, Cache = @cache, Language = @language, Options = @options});
		}

		///<summary>Say something using text-to-speech on a media player with picotts.</summary>
		public void PicottsSay(TtsPicottsSayParameters data)
		{
			_haContext.CallService("tts", "picotts_say", null, data);
		}

		///<summary>Say something using text-to-speech on a media player with picotts.</summary>
		///<param name="entityId">Name(s) of media player entities.</param>
		///<param name="message">Text to speak on devices. eg: My name is hanna</param>
		///<param name="cache">Control file cache of this message.</param>
		///<param name="language">Language to use for speech generation. eg: ru</param>
		///<param name="options">A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</param>
		public void PicottsSay(string @entityId, string @message, bool? @cache = null, string? @language = null, object? @options = null)
		{
			_haContext.CallService("tts", "picotts_say", null, new TtsPicottsSayParameters{EntityId = @entityId, Message = @message, Cache = @cache, Language = @language, Options = @options});
		}
	}

	public record TtsGoogleTranslateSayParameters
	{
		///<summary>Name(s) of media player entities.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Text to speak on devices. eg: My name is hanna</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Control file cache of this message.</summary>
		[JsonPropertyName("cache")]
		public bool? Cache { get; init; }

		///<summary>Language to use for speech generation. eg: ru</summary>
		[JsonPropertyName("language")]
		public string? Language { get; init; }

		///<summary>A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public record TtsPicottsSayParameters
	{
		///<summary>Name(s) of media player entities.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Text to speak on devices. eg: My name is hanna</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Control file cache of this message.</summary>
		[JsonPropertyName("cache")]
		public bool? Cache { get; init; }

		///<summary>Language to use for speech generation. eg: ru</summary>
		[JsonPropertyName("language")]
		public string? Language { get; init; }

		///<summary>A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class UpdateServices
	{
		private readonly IHaContext _haContext;
		public UpdateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Removes the skipped version marker from an update.</summary>
		///<param name="target">The target for this service call</param>
		public void ClearSkipped(ServiceTarget target)
		{
			_haContext.CallService("update", "clear_skipped", target);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The target for this service call</param>
		public void Install(ServiceTarget target, UpdateInstallParameters data)
		{
			_haContext.CallService("update", "install", target, data);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The target for this service call</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public void Install(ServiceTarget target, string? @version = null, bool? @backup = null)
		{
			_haContext.CallService("update", "install", target, new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Mark currently available update as skipped.</summary>
		///<param name="target">The target for this service call</param>
		public void Skip(ServiceTarget target)
		{
			_haContext.CallService("update", "skip", target);
		}
	}

	public record UpdateInstallParameters
	{
		///<summary>Version to install, if omitted, the latest version will be installed. eg: 1.0.0</summary>
		[JsonPropertyName("version")]
		public string? Version { get; init; }

		///<summary>Backup before installing the update, if supported by the integration.</summary>
		[JsonPropertyName("backup")]
		public bool? Backup { get; init; }
	}

	public class UtilityMeterServices
	{
		private readonly IHaContext _haContext;
		public UtilityMeterServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Calibrates a utility meter sensor.</summary>
		///<param name="target">The target for this service call</param>
		public void Calibrate(ServiceTarget target, UtilityMeterCalibrateParameters data)
		{
			_haContext.CallService("utility_meter", "calibrate", target, data);
		}

		///<summary>Calibrates a utility meter sensor.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">Value to which set the meter eg: 100</param>
		public void Calibrate(ServiceTarget target, string @value)
		{
			_haContext.CallService("utility_meter", "calibrate", target, new UtilityMeterCalibrateParameters{Value = @value});
		}

		///<summary>Resets all counters of a utility meter.</summary>
		///<param name="target">The target for this service call</param>
		public void Reset(ServiceTarget target)
		{
			_haContext.CallService("utility_meter", "reset", target);
		}
	}

	public record UtilityMeterCalibrateParameters
	{
		///<summary>Value to which set the meter eg: 100</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class VacuumServices
	{
		private readonly IHaContext _haContext;
		public VacuumServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Tell the vacuum cleaner to do a spot clean-up.</summary>
		///<param name="target">The target for this service call</param>
		public void CleanSpot(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "clean_spot", target);
		}

		///<summary>Locate the vacuum cleaner robot.</summary>
		///<param name="target">The target for this service call</param>
		public void Locate(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "locate", target);
		}

		///<summary>Pause the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Pause(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "pause", target);
		}

		///<summary>Tell the vacuum cleaner to return to its dock.</summary>
		///<param name="target">The target for this service call</param>
		public void ReturnToBase(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "return_to_base", target);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		public void SendCommand(ServiceTarget target, VacuumSendCommandParameters data)
		{
			_haContext.CallService("vacuum", "send_command", target, data);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="command">Command to execute. eg: set_dnd_timer</param>
		///<param name="params">Parameters for the command. eg: { "key": "value" }</param>
		public void SendCommand(ServiceTarget target, string @command, object? @params = null)
		{
			_haContext.CallService("vacuum", "send_command", target, new VacuumSendCommandParameters{Command = @command, Params = @params});
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		public void SetFanSpeed(ServiceTarget target, VacuumSetFanSpeedParameters data)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, data);
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="fanSpeed">Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</param>
		public void SetFanSpeed(ServiceTarget target, string @fanSpeed)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, new VacuumSetFanSpeedParameters{FanSpeed = @fanSpeed});
		}

		///<summary>Start or resume the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Start(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start", target);
		}

		///<summary>Start, pause, or resume the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void StartPause(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start_pause", target);
		}

		///<summary>Stop the current cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Stop(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "stop", target);
		}

		public void Toggle()
		{
			_haContext.CallService("vacuum", "toggle", null);
		}

		///<summary>Stop the current cleaning task and return to home.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_off", target);
		}

		///<summary>Start a new cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_on", target);
		}
	}

	public record VacuumSendCommandParameters
	{
		///<summary>Command to execute. eg: set_dnd_timer</summary>
		[JsonPropertyName("command")]
		public string? Command { get; init; }

		///<summary>Parameters for the command. eg: { "key": "value" }</summary>
		[JsonPropertyName("params")]
		public object? Params { get; init; }
	}

	public record VacuumSetFanSpeedParameters
	{
		///<summary>Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</summary>
		[JsonPropertyName("fan_speed")]
		public string? FanSpeed { get; init; }
	}

	public class WakeOnLanServices
	{
		private readonly IHaContext _haContext;
		public WakeOnLanServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send a 'magic packet' to wake up a device with 'Wake-On-LAN' capabilities.</summary>
		public void SendMagicPacket(WakeOnLanSendMagicPacketParameters data)
		{
			_haContext.CallService("wake_on_lan", "send_magic_packet", null, data);
		}

		///<summary>Send a 'magic packet' to wake up a device with 'Wake-On-LAN' capabilities.</summary>
		///<param name="mac">MAC address of the device to wake up. eg: aa:bb:cc:dd:ee:ff</param>
		///<param name="broadcastAddress">Broadcast IP where to send the magic packet. eg: 192.168.255.255</param>
		///<param name="broadcastPort">Port where to send the magic packet.</param>
		public void SendMagicPacket(string @mac, string? @broadcastAddress = null, long? @broadcastPort = null)
		{
			_haContext.CallService("wake_on_lan", "send_magic_packet", null, new WakeOnLanSendMagicPacketParameters{Mac = @mac, BroadcastAddress = @broadcastAddress, BroadcastPort = @broadcastPort});
		}
	}

	public record WakeOnLanSendMagicPacketParameters
	{
		///<summary>MAC address of the device to wake up. eg: aa:bb:cc:dd:ee:ff</summary>
		[JsonPropertyName("mac")]
		public string? Mac { get; init; }

		///<summary>Broadcast IP where to send the magic packet. eg: 192.168.255.255</summary>
		[JsonPropertyName("broadcast_address")]
		public string? BroadcastAddress { get; init; }

		///<summary>Port where to send the magic packet.</summary>
		[JsonPropertyName("broadcast_port")]
		public long? BroadcastPort { get; init; }
	}

	public class ZoneServices
	{
		private readonly IHaContext _haContext;
		public ZoneServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the YAML-based zone configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("zone", "reload", null);
		}
	}

	public static class AutomationEntityExtensionMethods
	{
		///<summary>Toggle (enable / disable) an automation.</summary>
		public static void Toggle(this AutomationEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle (enable / disable) an automation.</summary>
		public static void Toggle(this IEnumerable<AutomationEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Trigger the actions of an automation.</summary>
		public static void Trigger(this AutomationEntity target, AutomationTriggerParameters data)
		{
			target.CallService("trigger", data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		public static void Trigger(this IEnumerable<AutomationEntity> target, AutomationTriggerParameters data)
		{
			target.CallService("trigger", data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The AutomationEntity to call this service for</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public static void Trigger(this AutomationEntity target, bool? @skipCondition = null)
		{
			target.CallService("trigger", new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The IEnumerable<AutomationEntity> to call this service for</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public static void Trigger(this IEnumerable<AutomationEntity> target, bool? @skipCondition = null)
		{
			target.CallService("trigger", new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Disable an automation.</summary>
		public static void TurnOff(this AutomationEntity target, AutomationTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Disable an automation.</summary>
		public static void TurnOff(this IEnumerable<AutomationEntity> target, AutomationTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The AutomationEntity to call this service for</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public static void TurnOff(this AutomationEntity target, bool? @stopActions = null)
		{
			target.CallService("turn_off", new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The IEnumerable<AutomationEntity> to call this service for</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public static void TurnOff(this IEnumerable<AutomationEntity> target, bool? @stopActions = null)
		{
			target.CallService("turn_off", new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Enable an automation.</summary>
		public static void TurnOn(this AutomationEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Enable an automation.</summary>
		public static void TurnOn(this IEnumerable<AutomationEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class ButtonEntityExtensionMethods
	{
		///<summary>Press the button entity.</summary>
		public static void Press(this ButtonEntity target)
		{
			target.CallService("press");
		}

		///<summary>Press the button entity.</summary>
		public static void Press(this IEnumerable<ButtonEntity> target)
		{
			target.CallService("press");
		}
	}

	public static class InputBooleanEntityExtensionMethods
	{
		///<summary>Toggle an input boolean</summary>
		public static void Toggle(this InputBooleanEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle an input boolean</summary>
		public static void Toggle(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn off an input boolean</summary>
		public static void TurnOff(this InputBooleanEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn off an input boolean</summary>
		public static void TurnOff(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn on an input boolean</summary>
		public static void TurnOn(this InputBooleanEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn on an input boolean</summary>
		public static void TurnOn(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class InputDatetimeEntityExtensionMethods
	{
		///<summary>This can be used to dynamically set the date and/or time.</summary>
		public static void SetDatetime(this InputDatetimeEntity target, InputDatetimeSetDatetimeParameters data)
		{
			target.CallService("set_datetime", data);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		public static void SetDatetime(this IEnumerable<InputDatetimeEntity> target, InputDatetimeSetDatetimeParameters data)
		{
			target.CallService("set_datetime", data);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The InputDatetimeEntity to call this service for</param>
		///<param name="date">The target date the entity should be set to. eg: "2019-04-20"</param>
		///<param name="time">The target time the entity should be set to. eg: "05:04:20"</param>
		///<param name="datetime">The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</param>
		///<param name="timestamp">The target date & time the entity should be set to as expressed by a UNIX timestamp.</param>
		public static void SetDatetime(this InputDatetimeEntity target, string? @date = null, DateTime? @time = null, string? @datetime = null, long? @timestamp = null)
		{
			target.CallService("set_datetime", new InputDatetimeSetDatetimeParameters{Date = @date, Time = @time, Datetime = @datetime, Timestamp = @timestamp});
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The IEnumerable<InputDatetimeEntity> to call this service for</param>
		///<param name="date">The target date the entity should be set to. eg: "2019-04-20"</param>
		///<param name="time">The target time the entity should be set to. eg: "05:04:20"</param>
		///<param name="datetime">The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</param>
		///<param name="timestamp">The target date & time the entity should be set to as expressed by a UNIX timestamp.</param>
		public static void SetDatetime(this IEnumerable<InputDatetimeEntity> target, string? @date = null, DateTime? @time = null, string? @datetime = null, long? @timestamp = null)
		{
			target.CallService("set_datetime", new InputDatetimeSetDatetimeParameters{Date = @date, Time = @time, Datetime = @datetime, Timestamp = @timestamp});
		}
	}

	public static class InputNumberEntityExtensionMethods
	{
		///<summary>Decrement the value of an input number entity by its stepping.</summary>
		public static void Decrement(this InputNumberEntity target)
		{
			target.CallService("decrement");
		}

		///<summary>Decrement the value of an input number entity by its stepping.</summary>
		public static void Decrement(this IEnumerable<InputNumberEntity> target)
		{
			target.CallService("decrement");
		}

		///<summary>Increment the value of an input number entity by its stepping.</summary>
		public static void Increment(this InputNumberEntity target)
		{
			target.CallService("increment");
		}

		///<summary>Increment the value of an input number entity by its stepping.</summary>
		public static void Increment(this IEnumerable<InputNumberEntity> target)
		{
			target.CallService("increment");
		}

		///<summary>Set the value of an input number entity.</summary>
		public static void SetValue(this InputNumberEntity target, InputNumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of an input number entity.</summary>
		public static void SetValue(this IEnumerable<InputNumberEntity> target, InputNumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The InputNumberEntity to call this service for</param>
		///<param name="value">The target value the entity should be set to.</param>
		public static void SetValue(this InputNumberEntity target, double @value)
		{
			target.CallService("set_value", new InputNumberSetValueParameters{Value = @value});
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The IEnumerable<InputNumberEntity> to call this service for</param>
		///<param name="value">The target value the entity should be set to.</param>
		public static void SetValue(this IEnumerable<InputNumberEntity> target, double @value)
		{
			target.CallService("set_value", new InputNumberSetValueParameters{Value = @value});
		}
	}

	public static class InputSelectEntityExtensionMethods
	{
		///<summary>Select the first option of an input select entity.</summary>
		public static void SelectFirst(this InputSelectEntity target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the first option of an input select entity.</summary>
		public static void SelectFirst(this IEnumerable<InputSelectEntity> target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the last option of an input select entity.</summary>
		public static void SelectLast(this InputSelectEntity target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the last option of an input select entity.</summary>
		public static void SelectLast(this IEnumerable<InputSelectEntity> target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the next options of an input select entity.</summary>
		public static void SelectNext(this InputSelectEntity target, InputSelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		public static void SelectNext(this IEnumerable<InputSelectEntity> target, InputSelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this InputSelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_next", new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this IEnumerable<InputSelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_next", new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an input select entity.</summary>
		public static void SelectOption(this InputSelectEntity target, InputSelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an input select entity.</summary>
		public static void SelectOption(this IEnumerable<InputSelectEntity> target, InputSelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this InputSelectEntity target, string @option)
		{
			target.CallService("select_option", new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this IEnumerable<InputSelectEntity> target, string @option)
		{
			target.CallService("select_option", new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		public static void SelectPrevious(this InputSelectEntity target, InputSelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		public static void SelectPrevious(this IEnumerable<InputSelectEntity> target, InputSelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this InputSelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_previous", new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this IEnumerable<InputSelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_previous", new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Set the options of an input select entity.</summary>
		public static void SetOptions(this InputSelectEntity target, InputSelectSetOptionsParameters data)
		{
			target.CallService("set_options", data);
		}

		///<summary>Set the options of an input select entity.</summary>
		public static void SetOptions(this IEnumerable<InputSelectEntity> target, InputSelectSetOptionsParameters data)
		{
			target.CallService("set_options", data);
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public static void SetOptions(this InputSelectEntity target, object @options)
		{
			target.CallService("set_options", new InputSelectSetOptionsParameters{Options = @options});
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public static void SetOptions(this IEnumerable<InputSelectEntity> target, object @options)
		{
			target.CallService("set_options", new InputSelectSetOptionsParameters{Options = @options});
		}
	}

	public static class InputTextEntityExtensionMethods
	{
		///<summary>Set the value of an input text entity.</summary>
		public static void SetValue(this InputTextEntity target, InputTextSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of an input text entity.</summary>
		public static void SetValue(this IEnumerable<InputTextEntity> target, InputTextSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The InputTextEntity to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: This is an example text</param>
		public static void SetValue(this InputTextEntity target, string @value)
		{
			target.CallService("set_value", new InputTextSetValueParameters{Value = @value});
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The IEnumerable<InputTextEntity> to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: This is an example text</param>
		public static void SetValue(this IEnumerable<InputTextEntity> target, string @value)
		{
			target.CallService("set_value", new InputTextSetValueParameters{Value = @value});
		}
	}

	public static class LightEntityExtensionMethods
	{
		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		public static void Toggle(this LightEntity target, LightToggleParameters data)
		{
			target.CallService("toggle", data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		public static void Toggle(this IEnumerable<LightEntity> target, LightToggleParameters data)
		{
			target.CallService("toggle", data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void Toggle(this LightEntity target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("toggle", new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void Toggle(this IEnumerable<LightEntity> target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("toggle", new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turns off one or more lights.</summary>
		public static void TurnOff(this LightEntity target, LightTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Turns off one or more lights.</summary>
		public static void TurnOff(this IEnumerable<LightEntity> target, LightTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public static void TurnOff(this LightEntity target, long? @transition = null, object? @flash = null)
		{
			target.CallService("turn_off", new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public static void TurnOff(this IEnumerable<LightEntity> target, long? @transition = null, object? @flash = null)
		{
			target.CallService("turn_off", new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		public static void TurnOn(this LightEntity target, LightTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		public static void TurnOn(this IEnumerable<LightEntity> target, LightTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void TurnOn(this LightEntity target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("turn_on", new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void TurnOn(this IEnumerable<LightEntity> target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("turn_on", new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}
	}

	public static class LockEntityExtensionMethods
	{
		///<summary>Lock all or specified locks.</summary>
		public static void Lock(this LockEntity target, LockLockParameters data)
		{
			target.CallService("lock", data);
		}

		///<summary>Lock all or specified locks.</summary>
		public static void Lock(this IEnumerable<LockEntity> target, LockLockParameters data)
		{
			target.CallService("lock", data);
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The LockEntity to call this service for</param>
		///<param name="code">An optional code to lock the lock with. eg: 1234</param>
		public static void Lock(this LockEntity target, string? @code = null)
		{
			target.CallService("lock", new LockLockParameters{Code = @code});
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The IEnumerable<LockEntity> to call this service for</param>
		///<param name="code">An optional code to lock the lock with. eg: 1234</param>
		public static void Lock(this IEnumerable<LockEntity> target, string? @code = null)
		{
			target.CallService("lock", new LockLockParameters{Code = @code});
		}

		///<summary>Open all or specified locks.</summary>
		public static void Open(this LockEntity target, LockOpenParameters data)
		{
			target.CallService("open", data);
		}

		///<summary>Open all or specified locks.</summary>
		public static void Open(this IEnumerable<LockEntity> target, LockOpenParameters data)
		{
			target.CallService("open", data);
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The LockEntity to call this service for</param>
		///<param name="code">An optional code to open the lock with. eg: 1234</param>
		public static void Open(this LockEntity target, string? @code = null)
		{
			target.CallService("open", new LockOpenParameters{Code = @code});
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The IEnumerable<LockEntity> to call this service for</param>
		///<param name="code">An optional code to open the lock with. eg: 1234</param>
		public static void Open(this IEnumerable<LockEntity> target, string? @code = null)
		{
			target.CallService("open", new LockOpenParameters{Code = @code});
		}

		///<summary>Unlock all or specified locks.</summary>
		public static void Unlock(this LockEntity target, LockUnlockParameters data)
		{
			target.CallService("unlock", data);
		}

		///<summary>Unlock all or specified locks.</summary>
		public static void Unlock(this IEnumerable<LockEntity> target, LockUnlockParameters data)
		{
			target.CallService("unlock", data);
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The LockEntity to call this service for</param>
		///<param name="code">An optional code to unlock the lock with. eg: 1234</param>
		public static void Unlock(this LockEntity target, string? @code = null)
		{
			target.CallService("unlock", new LockUnlockParameters{Code = @code});
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The IEnumerable<LockEntity> to call this service for</param>
		///<param name="code">An optional code to unlock the lock with. eg: 1234</param>
		public static void Unlock(this IEnumerable<LockEntity> target, string? @code = null)
		{
			target.CallService("unlock", new LockUnlockParameters{Code = @code});
		}
	}

	public static class MediaPlayerEntityExtensionMethods
	{
		///<summary>Send the media player the command to clear players playlist.</summary>
		public static void ClearPlaylist(this MediaPlayerEntity target)
		{
			target.CallService("clear_playlist");
		}

		///<summary>Send the media player the command to clear players playlist.</summary>
		public static void ClearPlaylist(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("clear_playlist");
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		public static void Join(this MediaPlayerEntity target, MediaPlayerJoinParameters data)
		{
			target.CallService("join", data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		public static void Join(this IEnumerable<MediaPlayerEntity> target, MediaPlayerJoinParameters data)
		{
			target.CallService("join", data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: - media_player.multiroom_player2 - media_player.multiroom_player3 </param>
		public static void Join(this MediaPlayerEntity target, string @groupMembers)
		{
			target.CallService("join", new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: - media_player.multiroom_player2 - media_player.multiroom_player3 </param>
		public static void Join(this IEnumerable<MediaPlayerEntity> target, string @groupMembers)
		{
			target.CallService("join", new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Send the media player the command for next track.</summary>
		public static void MediaNextTrack(this MediaPlayerEntity target)
		{
			target.CallService("media_next_track");
		}

		///<summary>Send the media player the command for next track.</summary>
		public static void MediaNextTrack(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_next_track");
		}

		///<summary>Send the media player the command for pause.</summary>
		public static void MediaPause(this MediaPlayerEntity target)
		{
			target.CallService("media_pause");
		}

		///<summary>Send the media player the command for pause.</summary>
		public static void MediaPause(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_pause");
		}

		///<summary>Send the media player the command for play.</summary>
		public static void MediaPlay(this MediaPlayerEntity target)
		{
			target.CallService("media_play");
		}

		///<summary>Send the media player the command for play.</summary>
		public static void MediaPlay(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_play");
		}

		///<summary>Toggle media player play/pause state.</summary>
		public static void MediaPlayPause(this MediaPlayerEntity target)
		{
			target.CallService("media_play_pause");
		}

		///<summary>Toggle media player play/pause state.</summary>
		public static void MediaPlayPause(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_play_pause");
		}

		///<summary>Send the media player the command for previous track.</summary>
		public static void MediaPreviousTrack(this MediaPlayerEntity target)
		{
			target.CallService("media_previous_track");
		}

		///<summary>Send the media player the command for previous track.</summary>
		public static void MediaPreviousTrack(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_previous_track");
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		public static void MediaSeek(this MediaPlayerEntity target, MediaPlayerMediaSeekParameters data)
		{
			target.CallService("media_seek", data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		public static void MediaSeek(this IEnumerable<MediaPlayerEntity> target, MediaPlayerMediaSeekParameters data)
		{
			target.CallService("media_seek", data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public static void MediaSeek(this MediaPlayerEntity target, double @seekPosition)
		{
			target.CallService("media_seek", new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public static void MediaSeek(this IEnumerable<MediaPlayerEntity> target, double @seekPosition)
		{
			target.CallService("media_seek", new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the stop command.</summary>
		public static void MediaStop(this MediaPlayerEntity target)
		{
			target.CallService("media_stop");
		}

		///<summary>Send the media player the stop command.</summary>
		public static void MediaStop(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_stop");
		}

		///<summary>Send the media player the command for playing media.</summary>
		public static void PlayMedia(this MediaPlayerEntity target, MediaPlayerPlayMediaParameters data)
		{
			target.CallService("play_media", data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		public static void PlayMedia(this IEnumerable<MediaPlayerEntity> target, MediaPlayerPlayMediaParameters data)
		{
			target.CallService("play_media", data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public static void PlayMedia(this MediaPlayerEntity target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			target.CallService("play_media", new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public static void PlayMedia(this IEnumerable<MediaPlayerEntity> target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			target.CallService("play_media", new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Set repeat mode</summary>
		public static void RepeatSet(this MediaPlayerEntity target, MediaPlayerRepeatSetParameters data)
		{
			target.CallService("repeat_set", data);
		}

		///<summary>Set repeat mode</summary>
		public static void RepeatSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerRepeatSetParameters data)
		{
			target.CallService("repeat_set", data);
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="repeat">Repeat mode to set.</param>
		public static void RepeatSet(this MediaPlayerEntity target, object @repeat)
		{
			target.CallService("repeat_set", new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="repeat">Repeat mode to set.</param>
		public static void RepeatSet(this IEnumerable<MediaPlayerEntity> target, object @repeat)
		{
			target.CallService("repeat_set", new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		public static void SelectSoundMode(this MediaPlayerEntity target, MediaPlayerSelectSoundModeParameters data)
		{
			target.CallService("select_sound_mode", data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		public static void SelectSoundMode(this IEnumerable<MediaPlayerEntity> target, MediaPlayerSelectSoundModeParameters data)
		{
			target.CallService("select_sound_mode", data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public static void SelectSoundMode(this MediaPlayerEntity target, string? @soundMode = null)
		{
			target.CallService("select_sound_mode", new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public static void SelectSoundMode(this IEnumerable<MediaPlayerEntity> target, string? @soundMode = null)
		{
			target.CallService("select_sound_mode", new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change input source.</summary>
		public static void SelectSource(this MediaPlayerEntity target, MediaPlayerSelectSourceParameters data)
		{
			target.CallService("select_source", data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		public static void SelectSource(this IEnumerable<MediaPlayerEntity> target, MediaPlayerSelectSourceParameters data)
		{
			target.CallService("select_source", data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public static void SelectSource(this MediaPlayerEntity target, string @source)
		{
			target.CallService("select_source", new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public static void SelectSource(this IEnumerable<MediaPlayerEntity> target, string @source)
		{
			target.CallService("select_source", new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Set shuffling state.</summary>
		public static void ShuffleSet(this MediaPlayerEntity target, MediaPlayerShuffleSetParameters data)
		{
			target.CallService("shuffle_set", data);
		}

		///<summary>Set shuffling state.</summary>
		public static void ShuffleSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerShuffleSetParameters data)
		{
			target.CallService("shuffle_set", data);
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public static void ShuffleSet(this MediaPlayerEntity target, bool @shuffle)
		{
			target.CallService("shuffle_set", new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public static void ShuffleSet(this IEnumerable<MediaPlayerEntity> target, bool @shuffle)
		{
			target.CallService("shuffle_set", new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Toggles a media player power state.</summary>
		public static void Toggle(this MediaPlayerEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggles a media player power state.</summary>
		public static void Toggle(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn a media player power off.</summary>
		public static void TurnOff(this MediaPlayerEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a media player power off.</summary>
		public static void TurnOff(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a media player power on.</summary>
		public static void TurnOn(this MediaPlayerEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn a media player power on.</summary>
		public static void TurnOn(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("turn_on");
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		public static void Unjoin(this MediaPlayerEntity target)
		{
			target.CallService("unjoin");
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		public static void Unjoin(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("unjoin");
		}

		///<summary>Turn a media player volume down.</summary>
		public static void VolumeDown(this MediaPlayerEntity target)
		{
			target.CallService("volume_down");
		}

		///<summary>Turn a media player volume down.</summary>
		public static void VolumeDown(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("volume_down");
		}

		///<summary>Mute a media player's volume.</summary>
		public static void VolumeMute(this MediaPlayerEntity target, MediaPlayerVolumeMuteParameters data)
		{
			target.CallService("volume_mute", data);
		}

		///<summary>Mute a media player's volume.</summary>
		public static void VolumeMute(this IEnumerable<MediaPlayerEntity> target, MediaPlayerVolumeMuteParameters data)
		{
			target.CallService("volume_mute", data);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public static void VolumeMute(this MediaPlayerEntity target, bool @isVolumeMuted)
		{
			target.CallService("volume_mute", new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public static void VolumeMute(this IEnumerable<MediaPlayerEntity> target, bool @isVolumeMuted)
		{
			target.CallService("volume_mute", new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Set a media player's volume level.</summary>
		public static void VolumeSet(this MediaPlayerEntity target, MediaPlayerVolumeSetParameters data)
		{
			target.CallService("volume_set", data);
		}

		///<summary>Set a media player's volume level.</summary>
		public static void VolumeSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerVolumeSetParameters data)
		{
			target.CallService("volume_set", data);
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public static void VolumeSet(this MediaPlayerEntity target, double @volumeLevel)
		{
			target.CallService("volume_set", new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public static void VolumeSet(this IEnumerable<MediaPlayerEntity> target, double @volumeLevel)
		{
			target.CallService("volume_set", new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Turn a media player volume up.</summary>
		public static void VolumeUp(this MediaPlayerEntity target)
		{
			target.CallService("volume_up");
		}

		///<summary>Turn a media player volume up.</summary>
		public static void VolumeUp(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("volume_up");
		}
	}

	public static class NumberEntityExtensionMethods
	{
		///<summary>Set the value of a Number entity.</summary>
		public static void SetValue(this NumberEntity target, NumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of a Number entity.</summary>
		public static void SetValue(this IEnumerable<NumberEntity> target, NumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The NumberEntity to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public static void SetValue(this NumberEntity target, string? @value = null)
		{
			target.CallService("set_value", new NumberSetValueParameters{Value = @value});
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The IEnumerable<NumberEntity> to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public static void SetValue(this IEnumerable<NumberEntity> target, string? @value = null)
		{
			target.CallService("set_value", new NumberSetValueParameters{Value = @value});
		}
	}

	public static class SceneEntityExtensionMethods
	{
		///<summary>Activate a scene.</summary>
		public static void TurnOn(this SceneEntity target, SceneTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Activate a scene.</summary>
		public static void TurnOn(this IEnumerable<SceneEntity> target, SceneTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The SceneEntity to call this service for</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public static void TurnOn(this SceneEntity target, long? @transition = null)
		{
			target.CallService("turn_on", new SceneTurnOnParameters{Transition = @transition});
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The IEnumerable<SceneEntity> to call this service for</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public static void TurnOn(this IEnumerable<SceneEntity> target, long? @transition = null)
		{
			target.CallService("turn_on", new SceneTurnOnParameters{Transition = @transition});
		}
	}

	public static class ScriptEntityExtensionMethods
	{
		///<summary>Toggle script</summary>
		public static void Toggle(this ScriptEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle script</summary>
		public static void Toggle(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn off script</summary>
		public static void TurnOff(this ScriptEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn off script</summary>
		public static void TurnOff(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn on script</summary>
		public static void TurnOn(this ScriptEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn on script</summary>
		public static void TurnOn(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class SelectEntityExtensionMethods
	{
		///<summary>Select the first option of an select entity.</summary>
		public static void SelectFirst(this SelectEntity target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the first option of an select entity.</summary>
		public static void SelectFirst(this IEnumerable<SelectEntity> target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the last option of an select entity.</summary>
		public static void SelectLast(this SelectEntity target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the last option of an select entity.</summary>
		public static void SelectLast(this IEnumerable<SelectEntity> target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the next options of an select entity.</summary>
		public static void SelectNext(this SelectEntity target, SelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an select entity.</summary>
		public static void SelectNext(this IEnumerable<SelectEntity> target, SelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an select entity.</summary>
		///<param name="target">The SelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this SelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_next", new SelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select the next options of an select entity.</summary>
		///<param name="target">The IEnumerable<SelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this IEnumerable<SelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_next", new SelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an select entity.</summary>
		public static void SelectOption(this SelectEntity target, SelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an select entity.</summary>
		public static void SelectOption(this IEnumerable<SelectEntity> target, SelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The SelectEntity to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this SelectEntity target, string @option)
		{
			target.CallService("select_option", new SelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The IEnumerable<SelectEntity> to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this IEnumerable<SelectEntity> target, string @option)
		{
			target.CallService("select_option", new SelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an select entity.</summary>
		public static void SelectPrevious(this SelectEntity target, SelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an select entity.</summary>
		public static void SelectPrevious(this IEnumerable<SelectEntity> target, SelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an select entity.</summary>
		///<param name="target">The SelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this SelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_previous", new SelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Select the previous options of an select entity.</summary>
		///<param name="target">The IEnumerable<SelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this IEnumerable<SelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_previous", new SelectSelectPreviousParameters{Cycle = @cycle});
		}
	}

	public static class SwitchEntityExtensionMethods
	{
		///<summary>Toggles a switch state</summary>
		public static void Toggle(this SwitchEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggles a switch state</summary>
		public static void Toggle(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn a switch off</summary>
		public static void TurnOff(this SwitchEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a switch off</summary>
		public static void TurnOff(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a switch on</summary>
		public static void TurnOn(this SwitchEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn a switch on</summary>
		public static void TurnOn(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class UpdateEntityExtensionMethods
	{
		///<summary>Removes the skipped version marker from an update.</summary>
		public static void ClearSkipped(this UpdateEntity target)
		{
			target.CallService("clear_skipped");
		}

		///<summary>Removes the skipped version marker from an update.</summary>
		public static void ClearSkipped(this IEnumerable<UpdateEntity> target)
		{
			target.CallService("clear_skipped");
		}

		///<summary>Install an update for this device or service</summary>
		public static void Install(this UpdateEntity target, UpdateInstallParameters data)
		{
			target.CallService("install", data);
		}

		///<summary>Install an update for this device or service</summary>
		public static void Install(this IEnumerable<UpdateEntity> target, UpdateInstallParameters data)
		{
			target.CallService("install", data);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The UpdateEntity to call this service for</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public static void Install(this UpdateEntity target, string? @version = null, bool? @backup = null)
		{
			target.CallService("install", new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The IEnumerable<UpdateEntity> to call this service for</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public static void Install(this IEnumerable<UpdateEntity> target, string? @version = null, bool? @backup = null)
		{
			target.CallService("install", new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Mark currently available update as skipped.</summary>
		public static void Skip(this UpdateEntity target)
		{
			target.CallService("skip");
		}

		///<summary>Mark currently available update as skipped.</summary>
		public static void Skip(this IEnumerable<UpdateEntity> target)
		{
			target.CallService("skip");
		}
	}

	public static class UtilityMeterEntityExtensionMethods
	{
		///<summary>Calibrates a utility meter sensor.</summary>
		public static void Calibrate(this SensorEntity target, UtilityMeterCalibrateParameters data)
		{
			target.CallService("calibrate", data);
		}

		///<summary>Calibrates a utility meter sensor.</summary>
		public static void Calibrate(this IEnumerable<SensorEntity> target, UtilityMeterCalibrateParameters data)
		{
			target.CallService("calibrate", data);
		}

		///<summary>Calibrates a utility meter sensor.</summary>
		///<param name="target">The SensorEntity to call this service for</param>
		///<param name="value">Value to which set the meter eg: 100</param>
		public static void Calibrate(this SensorEntity target, string @value)
		{
			target.CallService("calibrate", new UtilityMeterCalibrateParameters{Value = @value});
		}

		///<summary>Calibrates a utility meter sensor.</summary>
		///<param name="target">The IEnumerable<SensorEntity> to call this service for</param>
		///<param name="value">Value to which set the meter eg: 100</param>
		public static void Calibrate(this IEnumerable<SensorEntity> target, string @value)
		{
			target.CallService("calibrate", new UtilityMeterCalibrateParameters{Value = @value});
		}

		///<summary>Resets all counters of a utility meter.</summary>
		public static void Reset(this SelectEntity target)
		{
			target.CallService("reset");
		}

		///<summary>Resets all counters of a utility meter.</summary>
		public static void Reset(this IEnumerable<SelectEntity> target)
		{
			target.CallService("reset");
		}
	}
}