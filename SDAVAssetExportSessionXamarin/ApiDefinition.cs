using System;
using AVFoundation;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;

namespace Xamarin.SDAVAssetExportSession
{
	// @interface SDAVAssetExportSession : NSObject
	[BaseType(typeof(NSObject))]
	interface SDAVAssetExportSession
	{
		[Wrap("WeakDelegate")]
		SDAVAssetExportSessionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SDAVAssetExportSessionDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) AVAsset * asset;
		[Export("asset", ArgumentSemantic.Strong)]
		AVAsset Asset { get; }

		// @property (copy, nonatomic) AVVideoComposition * videoComposition;
		[Export("videoComposition", ArgumentSemantic.Copy)]
		AVVideoComposition VideoComposition { get; set; }

		// @property (copy, nonatomic) AVAudioMix * audioMix;
		[Export("audioMix", ArgumentSemantic.Copy)]
		AVAudioMix AudioMix { get; set; }

		// @property (copy, nonatomic) NSString * outputFileType;
		[Export("outputFileType")]
		string OutputFileType { get; set; }

		// @property (copy, nonatomic) NSURL * outputURL;
		[Export("outputURL", ArgumentSemantic.Copy)]
		NSUrl OutputURL { get; set; }

		// @property (copy, nonatomic) NSDictionary * videoInputSettings;
		[Export("videoInputSettings", ArgumentSemantic.Copy)]
		NSDictionary VideoInputSettings { get; set; }

		// @property (copy, nonatomic) NSDictionary * videoSettings;
		[Export("videoSettings", ArgumentSemantic.Copy)]
		NSDictionary VideoSettings { get; set; }

		// @property (copy, nonatomic) NSDictionary * audioSettings;
		[Export("audioSettings", ArgumentSemantic.Copy)]
		NSDictionary AudioSettings { get; set; }

		// @property (assign, nonatomic) CMTimeRange timeRange;
		[Export("timeRange", ArgumentSemantic.Assign)]
		CMTimeRange TimeRange { get; set; }

		// @property (assign, nonatomic) BOOL shouldOptimizeForNetworkUse;
		[Export("shouldOptimizeForNetworkUse")]
		bool ShouldOptimizeForNetworkUse { get; set; }

		// @property (assign, nonatomic) BOOL canPerformMultiplePassesOverSourceMediaData;
		[Export("canPerformMultiplePassesOverSourceMediaData")]
		bool CanPerformMultiplePassesOverSourceMediaData { get; set; }

		// @property (copy, nonatomic) NSArray * metadata;
		[Export("metadata", ArgumentSemantic.Copy)]
		AVMetadataItem[] Metadata { get; set; }

		// @property (readonly, nonatomic, strong) NSError * error;
		[Export("error", ArgumentSemantic.Strong)]
		NSError Error { get; }

		// @property (readonly, assign, nonatomic) float progress;
		[Export("progress")]
		float Progress { get; }

		// @property (readonly, assign, nonatomic) AVAssetExportSessionStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		AVAssetExportSessionStatus Status { get; }

		// +(id)exportSessionWithAsset:(AVAsset *)asset;
		[Static]
		[Export("exportSessionWithAsset:")]
		NSObject ExportSessionWithAsset(AVAsset asset);

		// -(id)initWithAsset:(AVAsset *)asset;
		[Export("initWithAsset:")]
		IntPtr Constructor(AVAsset asset);

		// -(void)exportAsynchronouslyWithCompletionHandler:(void (^)(void))handler;
		[Export("exportAsynchronouslyWithCompletionHandler:")]
		void ExportAsynchronouslyWithCompletionHandler(Action handler);

		// -(void)cancelExport;
		[Export("cancelExport")]
		void CancelExport();
	}

	// @protocol SDAVAssetExportSessionDelegate <NSObject>
	[BaseType(typeof(NSObject))]
	[Model]
	interface SDAVAssetExportSessionDelegate
	{
		// @required -(void)exportSession:(SDAVAssetExportSession *)exportSession renderFrame:(CVPixelBufferRef)pixelBuffer withPresentationTime:(CMTime)presentationTime toBuffer:(CVPixelBufferRef)renderBuffer;
		[Abstract]
		[Export("exportSession:renderFrame:withPresentationTime:toBuffer:")]
		unsafe void RenderFrame(SDAVAssetExportSession exportSession, IntPtr pixelBuffer, CMTime presentationTime, IntPtr renderBuffer);
	}
}
