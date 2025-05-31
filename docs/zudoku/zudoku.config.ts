import type {ZudokuConfig} from "zudoku";

const config: ZudokuConfig = {
    topNavigation: [
        {id: "docs", label: "Documentation"},
        {id: "api", label: "API Reference"},
    ],
    sidebar: {
        docs: [
            {
                type: "category",
                label: "Overview",
                items: ["docs/installation", "docs/authorization", "docs/about"],
            },
        ],
    },
    redirects: [
        {from: "/", to: "HotelBookingSystem//docs"},
    ],

    apis: {
        type: "file",
        input: "./apis/openapi.json",
        navigationId: "api",
    },
    docs: {
        files: "/pages/*/.{md,mdx}",
    },
};

export default config;