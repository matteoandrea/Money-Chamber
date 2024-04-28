import { onMount } from "solid-js";

export default function Login() {
  onMount(() => {
    console.log("aaa");
  });

  return (
    <div>
      <div class="card w-96 bg-base-100 shadow-xl">
        <figure>
          <img
            src="https://daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.jpg"
            alt="Shoes"
          />
        </figure>
        <div class="card-body">
          <h2 class="card-title">Shoes!</h2>
          <p>If a dog chews shoes whose shoes does he choose?</p>
          <div class="card-actions justify-end">
            <button class="btn btn-primary">Buy Now</button>
          </div>
        </div>
      </div>

      <div class="min-h-screen flex items-center justify-center bg-gradient-to-t from-eeaeca via-white to-94bbe9">
        {/* Your content goes here */}
        <p>This is a gradient background.</p>
      </div>
    </div>
  );
}
